using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class SmartGateConfigTests
{
    [Theory, ClassData(typeof(SmartGateConfigTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsSmartGateConfig(JsonNode row, JsonArray headers, string data)
    {
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