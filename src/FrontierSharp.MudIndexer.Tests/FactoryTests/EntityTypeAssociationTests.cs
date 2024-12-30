using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EntityTypeAssociationTests
{
    [Theory, ClassData(typeof(EntityTypeAssociationTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEntityTypeAssociation(JsonNode row, JsonArray headers, string data)
    {
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