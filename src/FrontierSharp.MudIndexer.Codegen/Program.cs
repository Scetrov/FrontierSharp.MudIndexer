// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Codegen;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Mud.EncodingDecoding;

Console.WriteLine("EVE World Mud Tables C# Code Generator");

var url = "https://indexer.mud.garnetchain.com/tables";
var payload = @"
{
    ""address"": ""0x7fe660995b0c59b6975d5d59973e2668af6bb9c5"",
    ""query"": {
        ""name"": ""%""
    }
}";
var tables = new List<MudTableDefinition>();

try {
    using var client = new HttpClient();
    using var content = new StringContent(payload, Encoding.UTF8, "application/json");
    using var response = await client.PostAsync(url, content);

    if (!response.IsSuccessStatusCode) {
        Console.WriteLine($"Error: {response.StatusCode}");
        var errorBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Error details: {errorBody}");
        return;
    }

    var responseBody = await response.Content.ReadAsStreamAsync();
    var node = await JsonNode.ParseAsync(responseBody);

    Debug.Assert(node != null, nameof(node) + " != null");
    foreach (var table in node.AsArray()) {
        Debug.Assert(table != null, nameof(table) + " != null");
        Debug.Assert(table["table_id"] != null, nameof(table) + "[table_id] != null");
        Debug.Assert(table["key_names"] != null, nameof(table) + "[key_names] != null");
        Debug.Assert(table["val_names"] != null, nameof(table) + "[val_names] != null");
        Debug.Assert(table["key_schema"] != null, nameof(table) + "[key_schema] != null");
        Debug.Assert(table["val_schema"] != null, nameof(table) + "[val_schema] != null");
        var (tableNamespace, tableName) = MudExtensions.DecodeTableId(table["table_id"]!.GetValue<string>());

        if (tableNamespace is not "eveworld" and not "erc721deploybl" and not "erc721charactr" and not "store") {
            continue;
        }

        var keys = table["key_names"]!.AsArray().Select(x => x!.GetValue<string>()).ToArray();
        var values = table["val_names"]!.AsArray().Select(x => x!.GetValue<string>()).ToArray();
        var keySchema = SchemaEncoder.Decode(table["key_schema"]!.GetValue<string>().HexToByteArray())
            .ToArray();
        var valSchema = SchemaEncoder.Decode(table["val_schema"]!.GetValue<string>().HexToByteArray())
            .ToArray();

        var fields = keys.Select(key => new TableField { ParameterName = key, AbiType = keySchema[Array.IndexOf(keys, key)].Type }).ToList();
        fields.AddRange(values.Select(val => new TableField { ParameterName = val, AbiType = valSchema[Array.IndexOf(values, val)].Type }));

        tables.Add(new MudTableDefinition {
            Namespace = tableNamespace,
            TableName = tableName,
            Fields = fields
        });
    }
}
catch (Exception ex) {
    Console.WriteLine($"Exception occurred: {ex.Message}");
}

var currentDirectory = Directory.GetCurrentDirectory();
var solutionRoot = FactoryCodeGenerator.FindSolutionRoot(currentDirectory);

var dtoDirectory = Path.Combine(solutionRoot, "FrontierSharp.MudIndexer", "Tables");
var factoryDirectory = Path.Combine(solutionRoot, "FrontierSharp.MudIndexer", "Factories");
var testDataDirectory = Path.Combine(solutionRoot, "FrontierSharp.MudIndexer.Tests", "FactoryTests", "Data");
var testClassDirectory = Path.Combine(solutionRoot, "FrontierSharp.MudIndexer.Tests", "FactoryTests");

string[] outputDirectories = [dtoDirectory, factoryDirectory, testDataDirectory, testClassDirectory];

foreach (var directory in outputDirectories) {
    if (!Directory.Exists(directory)) {
        Directory.CreateDirectory(directory);
    }

    var filesToDelete = Directory.GetFiles(directory);
    
    if (filesToDelete.Length > 0) {
        foreach (var file in filesToDelete) {
            File.Delete(file);
        }
    }
}

foreach (var table in tables) {
    var dto = FactoryCodeGenerator.GenerateDataTransferObject(table);
    var factory = FactoryCodeGenerator.GenerateFactory(table);
    var testData = await FactoryCodeGenerator.GenerateTestData(table);
    var testClass = TestClassGenerator.GenerateTestClassCompilationUnit(table);

    if (testData.Trim().Equals("error code: 502", StringComparison.InvariantCultureIgnoreCase)) {
        Console.WriteLine($"Error: 502 Bad Gateway when generating test data for {table.TableName}, broken table, skipping...");
        continue;
    }

    var pascalCaseTableName = table.TableName.ExpandTableName().ToPascalCase();
    
    Console.WriteLine("Processing {0} as {1}...", table.TableName, pascalCaseTableName);
    
    var dtoPath = Path.Combine(dtoDirectory, $"{pascalCaseTableName}.cs");
    var factoryPath = Path.Combine(factoryDirectory, $"{pascalCaseTableName}Factory.cs");
    var testDataPath = Path.Combine(testDataDirectory, $"{pascalCaseTableName}.json");
    var testClassPath = Path.Combine(testClassDirectory, $"{pascalCaseTableName}Tests.cs");

    await File.WriteAllTextAsync(dtoPath, dto);
    await File.WriteAllTextAsync(factoryPath, factory);
    
    if (JsonNode.Parse(testData)?["result"]?[0]?.AsArray().Count is null or < 1) {
        Console.WriteLine($"Error: Table is empty, skipping testing...");
        continue;
    }
    
    await File.WriteAllTextAsync(testDataPath, testData);
    await File.WriteAllTextAsync(testClassPath, testClass);
}