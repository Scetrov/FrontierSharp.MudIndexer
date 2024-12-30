using System.Collections;
using System.Text.Json.Nodes;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;

public class FactoryTestData : IEnumerable<object[]> {
    const int SampleSize = 100;

    private readonly List<object[]> _data = [];
    
    protected void SetDataFile(string sourceFile) {
        var solutionRoot = FindSolutionRoot(Directory.GetCurrentDirectory());
        sourceFile = Path.Combine(solutionRoot, "FrontierSharp.MudIndexer.Tests", "FactoryTests", "Data", sourceFile);
        
        if (!File.Exists(sourceFile)) {
            throw new FileNotFoundException($"Unable to load test data, {sourceFile} was not found");
        }
        
        var text = File.ReadAllText(sourceFile);
        var node = JsonNode.Parse(text);

        if (node == null) {
            throw new InvalidOperationException($"Unable to load test data, {sourceFile} did not contain valid JSON.");
        }

        var rows = node["result"]?[0]?.AsArray();
        var header = rows?.First();

        if (rows == null || header == null) {
            throw new InvalidOperationException($"Unable to load headers or row from, {sourceFile}");
        }

        foreach (var row in SampleData(rows.Skip(1), SampleSize)) {
            _data.Add([row,  header.AsArray(), String.Join(", ", row.AsArray().Select(x => x!.ToString()))]);
        }
    }

    private IEnumerable<JsonNode> SampleData(IEnumerable<JsonNode?> input, int sampleSize) {
        var allData = input as JsonNode[] ?? input.ToArray();
        return (allData.Count() - 1 < sampleSize ? allData : allData
            .ToArray()
            .Where(x => x != null)
            .OrderBy(x => Guid.NewGuid())
            .Take(sampleSize))!;
    }
    
    public IEnumerator<object[]> GetEnumerator() {
        return _data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
    
    private static string FindSolutionRoot(string directory) {
        while (!string.IsNullOrEmpty(directory)) {
            if (Directory.GetFiles(directory, "*.sln").Length > 0)
                return directory;

            directory = Directory.GetParent(directory)?.FullName ??
                        throw new InvalidOperationException("Solution root not found");
        }

        throw new InvalidOperationException("Solution root not found");
    }
}