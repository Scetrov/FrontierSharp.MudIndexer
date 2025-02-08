using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EphemeralInventoryTests
{
    private readonly ITestOutputHelper _output;
    public EphemeralInventoryTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(EphemeralInventoryTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEphemeralInventory(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new EphemeralInventoryFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EphemeralInventoryTestData : FactoryTestData
    {
        public EphemeralInventoryTestData()
        {
            SetDataFile("EphemeralInventory.json");
        }
    }
}