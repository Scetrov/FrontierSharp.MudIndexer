using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class LocationTableTests
{
    [Theory, ClassData(typeof(LocationTableTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsLocationTable(JsonNode row, JsonArray headers, string data)
    {
        var factory = new LocationTableFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class LocationTableTestData : FactoryTestData
    {
        public LocationTableTestData()
        {
            SetDataFile("LocationTable.json");
        }
    }
}