using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FrontierSharp.MudIndexer.Codegen;

public class TestClassGenerator {
    public static string GenerateTestClassCompilationUnit(MudTableDefinition tableDefinition) {
        var targetClassName = tableDefinition.TableName.ExpandTableName().ToPascalCase();
        
        var usingDirectives = new[] {
            "System.Text.Json.Nodes",
            "FrontierSharp.MudIndexer.Factories",
            "Shouldly",
            "Xunit"
        };

        var usings = usingDirectives.Select(x => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(x)));

        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddUsings(usings.ToArray())
            .AddMembers(GenerateTestClass(targetClassName));
        
        return compilationUnit.NormalizeWhitespace().ToFullString();
    }

    static FileScopedNamespaceDeclarationSyntax GenerateTestClass(string className) {
        var namespaceDeclaration = SyntaxFactory
            .FileScopedNamespaceDeclaration(SyntaxFactory.ParseName("FrontierSharp.MudIndexer.Tests.FactoryTests"))
            .NormalizeWhitespace();

        var classDeclaration = SyntaxFactory.ClassDeclaration($"{className}Tests")
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddMembers(
                GenerateFromJsonNodeMethod(className),
                GenerateTestDataClass(className)
            );

        return namespaceDeclaration.AddMembers(classDeclaration);
    }

    static MethodDeclarationSyntax GenerateFromJsonNodeMethod(string className) {
        // Create the [Theory] attribute
        var theoryAttribute = SyntaxFactory.Attribute(SyntaxFactory.ParseName("Theory"));

        // Create the [ClassData(typeof(AccessEnforcementPerObjectTestData))] attribute
        var classDataAttribute = SyntaxFactory.Attribute(SyntaxFactory.ParseName("ClassData"))
            .WithArgumentList(SyntaxFactory.AttributeArgumentList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.AttributeArgument(
                        SyntaxFactory.TypeOfExpression(
                            SyntaxFactory.IdentifierName($"{className}TestData")
                        )
                    )
                )
            ));

        // Add the attributes to the method
        var attributeList = SyntaxFactory.AttributeList(
            SyntaxFactory.SeparatedList(new[] { theoryAttribute, classDataAttribute }));

        // Create parameters: JsonNode row, JsonArray headers
        var parameters = new[] {
            SyntaxFactory.Parameter(SyntaxFactory.Identifier("row"))
                .WithType(SyntaxFactory.ParseTypeName("JsonNode")),
            SyntaxFactory.Parameter(SyntaxFactory.Identifier("headers"))
                .WithType(SyntaxFactory.ParseTypeName("JsonArray")),
            SyntaxFactory.Parameter(SyntaxFactory.Identifier("data"))
                .WithType(SyntaxFactory.ParseTypeName("string")),
        };

        // Create the body of the method
        StatementSyntax[] statementSyntax =
            [GenerateSystemUnderTestStatement(className), GenerateLambdaStatement(), GenerateShouldNotBeNull()];

        // Create the method declaration
        return SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                $"FromJsonNode_WithValidJsonNode_Returns{className}"
            )
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddAttributeLists(attributeList)
            .AddParameterListParameters(parameters)
            .WithBody(SyntaxFactory.Block(statementSyntax));
    }

    static StatementSyntax GenerateSystemUnderTestStatement(string className) {
        // var factory = new AccessEnforcementPerObjectFactory();
        return SyntaxFactory.LocalDeclarationStatement(
            SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName("var"))
                .AddVariables(SyntaxFactory.VariableDeclarator("factory")
                    .WithInitializer(SyntaxFactory.EqualsValueClause(
                        SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName($"{className}Factory"))
                            .WithArgumentList(SyntaxFactory.ArgumentList())
                    ))
                )
        );
    }

    static StatementSyntax GenerateLambdaStatement() {
        return SyntaxFactory.LocalDeclarationStatement(
            SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName("var"))
                .AddVariables(SyntaxFactory.VariableDeclarator("node")
                    .WithInitializer(SyntaxFactory.EqualsValueClause(
                        SyntaxFactory.InvocationExpression(
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    SyntaxFactory.IdentifierName("Should"),
                                    SyntaxFactory.IdentifierName("NotThrow")
                                )
                            )
                            .WithArgumentList(SyntaxFactory.ArgumentList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.SimpleLambdaExpression(
                                            SyntaxFactory.Parameter(SyntaxFactory.Identifier("()")),
                                            SyntaxFactory.InvocationExpression(
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.IdentifierName("factory"),
                                                    SyntaxFactory.IdentifierName("FromJsonNode")
                                                )
                                            ).WithArgumentList(SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SeparatedList(new[] {
                                                    SyntaxFactory.Argument(SyntaxFactory.IdentifierName("row")),
                                                    SyntaxFactory.Argument(SyntaxFactory.IdentifierName("headers"))
                                                })
                                            ))
                                        )
                                    )
                                )
                            ))
                    ))
                )
        );
    }

    static StatementSyntax GenerateShouldNotBeNull() {
        // node.ShouldNotBeNull();
        return SyntaxFactory.ExpressionStatement(
            SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName("node"),
                    SyntaxFactory.IdentifierName("ShouldNotBeNull")
                )
            )
        );
    }

    static ClassDeclarationSyntax GenerateTestDataClass(string className) {
        // Create the constructor
        var constructor = SyntaxFactory.ConstructorDeclaration($"{className}TestData")
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .WithBody(SyntaxFactory.Block(
                SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.IdentifierName("SetDataFile")
                    ).WithArgumentList(SyntaxFactory.ArgumentList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Argument(
                                SyntaxFactory.LiteralExpression(
                                    SyntaxKind.StringLiteralExpression,
                                    SyntaxFactory.Literal($"{className}.json")
                                )
                            )
                        )
                    ))
                )
            ));

        // Create the class
        return SyntaxFactory.ClassDeclaration($"{className}TestData")
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword))
            .WithBaseList(
                SyntaxFactory.BaseList(
                    SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                        SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName("FactoryTestData"))
                    )
                )
            )
            .AddMembers(constructor);
    }
}