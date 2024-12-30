using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EntityTypeTests
{
    [Theory, ClassData(typeof(EntityTypeTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEntityType(JsonNode row, JsonArray headers, string data)
    {
        var factory = new EntityTypeFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EntityTypeTestData : FactoryTestData
    {
        public EntityTypeTestData()
        {
            SetDataFile("EntityType.json");
        }
    }
}