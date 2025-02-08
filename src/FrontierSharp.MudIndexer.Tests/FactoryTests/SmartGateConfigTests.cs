using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class SmartGateConfigTests
{
    private readonly ITestOutputHelper _output;
    public SmartGateConfigTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(SmartGateConfigTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsSmartGateConfig(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new SmartGateConfigFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class SmartGateConfigTestData : FactoryTestData
    {
        public SmartGateConfigTestData()
        {
            SetDataFile("SmartGateConfig.json");
        }
    }
}