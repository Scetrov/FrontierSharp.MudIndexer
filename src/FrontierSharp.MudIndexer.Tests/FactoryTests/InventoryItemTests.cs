using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class InventoryItemTests
{
    private readonly ITestOutputHelper _output;
    public InventoryItemTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(InventoryItemTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsInventoryItem(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new InventoryItemFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class InventoryItemTestData : FactoryTestData
    {
        public InventoryItemTestData()
        {
            SetDataFile("InventoryItem.json");
        }
    }
}