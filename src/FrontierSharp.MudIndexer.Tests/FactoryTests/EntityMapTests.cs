using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EntityMapTests
{
    [Theory, ClassData(typeof(EntityMapTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEntityMap(JsonNode row, JsonArray headers, string data)
    {
        var factory = new EntityMapFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EntityMapTestData : FactoryTestData
    {
        public EntityMapTestData()
        {
            SetDataFile("EntityMap.json");
        }
    }
}