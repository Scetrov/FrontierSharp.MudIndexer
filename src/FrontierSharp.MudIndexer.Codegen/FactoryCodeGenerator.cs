using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace FrontierSharp.MudIndexer.Codegen;

public static class FactoryCodeGenerator {
    public static string GenerateFactory(MudTableDefinition tableDefinition) {
        const string factoryNamespace = "FrontierSharp.MudIndexer.Factories";
        const string tableNamespace = "FrontierSharp.MudIndexer.Tables";

        var dtoName = tableDefinition.TableName.ExpandTableName().ToPascalCase();
        var factoryName = $"{dtoName}Factory";
        
        // Generate DefaultQuery
        var defaultQuery = GenerateDefaultQuery(tableDefinition);

        // Using directives
        var usings = new[] {
            SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Text.Json.Nodes")),
            SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(tableNamespace))
        };

        // Namespace declaration
        var namespaceDeclaration = SyntaxFactory
            .FileScopedNamespaceDeclaration(SyntaxFactory.ParseName(factoryNamespace))
            .AddUsings(usings);

        namespaceDeclaration = OptionallyAddSystemNumerics(tableDefinition, namespaceDeclaration);

        // DefaultQuery property
        var defaultQueryProperty = SyntaxFactory.PropertyDeclaration(
                SyntaxFactory.ParseTypeName("string"),
                "DefaultQuery")
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword))
            .WithExpressionBody(SyntaxFactory.ArrowExpressionClause(
                SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression,
                    SyntaxFactory.Literal(defaultQuery))))
            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

        // FromJsonNode method
        var fromJsonNodeMethod = GenerateFromJsonNodeMethod(tableDefinition);

        // Class declaration
        var classDeclaration = SyntaxFactory.ClassDeclaration(factoryName)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddBaseListTypes(
                SyntaxFactory.SimpleBaseType(
                    SyntaxFactory.GenericName("IFactory")
                        .AddTypeArgumentListArguments(SyntaxFactory.ParseTypeName(dtoName))
                )
            )
            .AddMembers(defaultQueryProperty, fromJsonNodeMethod);

        // Combine namespace and class into a compilation unit
        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddMembers(namespaceDeclaration.AddMembers(classDeclaration))
            .NormalizeWhitespace();

        return compilationUnit.ToFullString();
    }

    private static readonly Dictionary<string, string[]> ExcludedFields = new() {
        { "SmartGateConfigT", ["maxDistance"] },
        { "InventoryItemTab", ["stateUpdate"] },
        { "EphemeralInvItem", ["stateUpdate"] },
        { "EphemeralInvTabl", ["items"] },
        { "InventoryTable", ["usedCapacity", "items"] },
    };

    private static string GenerateDefaultQuery(MudTableDefinition tableDefinition) {
        var excludedFields = ExcludedFields.GetValueOrDefault(tableDefinition.TableName, []);
        var fields = tableDefinition.Fields.Where(x => !excludedFields.Contains(x.ParameterName))
            .Select(p => $"\"{p.ParameterName}\"");
        return
            $"SELECT {string.Join(", ", fields)} FROM {tableDefinition.Namespace}__{tableDefinition.TableName};";
    }

    public static string GenerateDataTransferObject(MudTableDefinition tableDefinition) {
        const string namespaceName = "FrontierSharp.MudIndexer.Tables";
        var className = tableDefinition.TableName.ExpandTableName().ToPascalCase();

        var namespaceDeclaration = SyntaxFactory.FileScopedNamespaceDeclaration(SyntaxFactory.ParseName(namespaceName));

        namespaceDeclaration = OptionallyAddSystemNumerics(tableDefinition, namespaceDeclaration);

        var propertyDeclarations = new List<MemberDeclarationSyntax>();
        var excludedFields = ExcludedFields.GetValueOrDefault(tableDefinition.TableName, []);
        foreach (var field in tableDefinition.Fields.Where(x => !excludedFields.Contains(x.ParameterName))) {
            var propertyDeclaration = SyntaxFactory
                .PropertyDeclaration(SyntaxFactory.ParseTypeName(field.GetCSharpType()),
                    GetFieldNameAsPascalCase(tableDefinition, field))
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddAccessorListAccessors(
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                )
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.RequiredKeyword));
            propertyDeclarations.Add(propertyDeclaration);
        }
        
        var classDeclaration = SyntaxFactory.ClassDeclaration(className)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddMembers(propertyDeclarations.ToArray());

        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddMembers(namespaceDeclaration.AddMembers(classDeclaration))
            .NormalizeWhitespace();

        return Format(compilationUnit).ToFullString();
    }

    private static string GetFieldNameAsPascalCase(MudTableDefinition tableDefinition, TableField field) {
        return tableDefinition.TableName.Equals(field.ParameterName, StringComparison.InvariantCultureIgnoreCase)
            ? $"{field.ParameterName.ToPascalCase()}Name"
            : field.ParameterName.ToPascalCase();
    }

    private static FileScopedNamespaceDeclarationSyntax OptionallyAddSystemNumerics(MudTableDefinition tableDefinition,
        FileScopedNamespaceDeclarationSyntax namespaceDeclaration) {
        if (tableDefinition.Fields.Any(x => x.GetCSharpType() == "BigInteger")) {
            namespaceDeclaration =
                namespaceDeclaration.AddUsings(
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Numerics")));
        }

        return namespaceDeclaration;
    }

    private static SyntaxNode Format(SyntaxNode syntaxNode) {
        var workspace = new AdhocWorkspace();

        // Configure K&R-style formatting options
        var options = workspace.Options
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInTypes, false)
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInMethods, false)
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInProperties, false)
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAccessors, false)
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInControlBlocks, false)
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAnonymousMethods, false)
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInLambdaExpressionBody, false)
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAnonymousTypes, false)
            .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInObjectCollectionArrayInitializers, false);

        return Formatter.Format(syntaxNode, workspace, options);
    }

    private static MethodDeclarationSyntax GenerateFromJsonNodeMethod(MudTableDefinition tableDefinition) {
        var returnType = SyntaxFactory.ParseTypeName(tableDefinition.TableName.ExpandTableName().ToPascalCase());
        var method = SyntaxFactory.MethodDeclaration(returnType, "FromJsonNode")
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .WithParameterList(
                SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList([
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier("node"))
                        .WithType(SyntaxFactory.IdentifierName("JsonNode")),
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier("headers"))
                        .WithType(SyntaxFactory.IdentifierName("JsonArray"))
                ]))
            )
            .WithExpressionBody(
                SyntaxFactory.ArrowExpressionClause(
                    SyntaxFactory.ObjectCreationExpression(returnType)
                        .WithInitializer(
                            SyntaxFactory.InitializerExpression(SyntaxKind.ObjectInitializerExpression,
                                SyntaxFactory.SeparatedList(
                                    GenerateAssignments(tableDefinition)
                                )
                            )
                        )
                )
            )
            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

        return method;
    }

    static IEnumerable<ExpressionSyntax> GenerateAssignments(MudTableDefinition tableDefinition) {
        var excludedFields = ExcludedFields.GetValueOrDefault(tableDefinition.TableName, []);
        foreach (var property in tableDefinition.Fields.Where(x => !excludedFields.Contains(x.ParameterName))) {
            yield return SyntaxFactory.AssignmentExpression(
                SyntaxKind.SimpleAssignmentExpression,
                SyntaxFactory.IdentifierName(GetFieldNameAsPascalCase(tableDefinition, property)),
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("node"),
                        SyntaxFactory.GenericName(SyntaxFactory.Identifier("GetValueFor"))
                            .WithTypeArgumentList(
                                SyntaxFactory.TypeArgumentList(
                                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                        SyntaxFactory.IdentifierName(property.GetCSharpType())
                                    )
                                )
                            )
                    )
                ).WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList([
                            SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression,
                                SyntaxFactory.Literal(property.ParameterName.ToPascalCase()))),
                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("headers"))
                        ])
                    )
                )
            );
        }
    }


    public static string FindSolutionRoot(string directory) {
        while (!string.IsNullOrEmpty(directory)) {
            if (Directory.GetFiles(directory, "*.sln").Length > 0)
                return directory;

            directory = Directory.GetParent(directory)?.FullName ??
                        throw new InvalidOperationException("Solution root not found");
        }

        throw new InvalidOperationException("Solution root not found");
    }

    public static async Task<string> GenerateTestData(MudTableDefinition table) {
        Console.WriteLine("Generating test data for {0}", table.TableName);
        using var client = new HttpClient();
        var query = GenerateDefaultQuery(table);
        // Console.WriteLine(generateDefaultQuery);
        var queryRequest = new List<QueryRequest> {
            new() {
                Address = "0x7fe660995b0c59b6975d5d59973e2668af6bb9c5",
                Query = query
            }
        };
        var json = JsonSerializer.Serialize(queryRequest);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("https://indexer.mud.garnetchain.com/q", content);

        if (!response.IsSuccessStatusCode) {
            Console.WriteLine($"Error: {response.StatusCode}");
            var errorBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error details: \n{errorBody}\n   Query: {query}");
            return errorBody;
        }

        return await response.Content.ReadAsStringAsync();
    }
}

public class QueryRequest {
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    [JsonPropertyName("address")] public required string Address { get; set; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    [JsonPropertyName("query")] public required string Query { get; set; }
}