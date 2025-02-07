using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class ResourceIdsTests
{
    [Theory, ClassData(typeof(ResourceIdsTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsResourceIds(JsonNode row, JsonArray headers, string data)
    {
        var factory = new ResourceIdsFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class ResourceIdsTestData : FactoryTestData
    {
        public ResourceIdsTestData()
        {
            SetDataFile("ResourceIds.json");
        }
    }
}