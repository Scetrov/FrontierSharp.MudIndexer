using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class ItemTransferTests
{
    private readonly ITestOutputHelper _output;
    public ItemTransferTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(ItemTransferTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsItemTransfer(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new ItemTransferFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class ItemTransferTestData : FactoryTestData
    {
        public ItemTransferTestData()
        {
            SetDataFile("ItemTransfer.json");
        }
    }
}