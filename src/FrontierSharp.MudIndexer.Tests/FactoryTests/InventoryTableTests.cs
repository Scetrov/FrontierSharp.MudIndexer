using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class InventoryTableTests
{
    [Theory, ClassData(typeof(InventoryTableTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsInventoryTable(JsonNode row, JsonArray headers, string data)
    {
        var factory = new InventoryTableFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class InventoryTableTestData : FactoryTestData
    {
        public InventoryTableTestData()
        {
            SetDataFile("InventoryTable.json");
        }
    }
}