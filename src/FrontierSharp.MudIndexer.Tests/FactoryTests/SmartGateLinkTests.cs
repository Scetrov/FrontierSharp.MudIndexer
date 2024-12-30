using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class SmartGateLinkTests
{
    [Theory, ClassData(typeof(SmartGateLinkTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsSmartGateLink(JsonNode row, JsonArray headers, string data)
    {
        var factory = new SmartGateLinkFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class SmartGateLinkTestData : FactoryTestData
    {
        public SmartGateLinkTestData()
        {
            SetDataFile("SmartGateLink.json");
        }
    }
}