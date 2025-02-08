using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class InventoryTableTests
{
    private readonly ITestOutputHelper _output;
    public InventoryTableTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(InventoryTableTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsInventoryTable(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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