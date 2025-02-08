using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EntityTypeAssociationTests
{
    private readonly ITestOutputHelper _output;
    public EntityTypeAssociationTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(EntityTypeAssociationTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEntityTypeAssociation(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new EntityTypeAssociationFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EntityTypeAssociationTestData : FactoryTestData
    {
        public EntityTypeAssociationTestData()
        {
            SetDataFile("EntityTypeAssociation.json");
        }
    }
}