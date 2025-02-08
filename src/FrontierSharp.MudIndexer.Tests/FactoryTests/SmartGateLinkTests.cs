using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class SmartGateLinkTests
{
    private readonly ITestOutputHelper _output;
    public SmartGateLinkTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(SmartGateLinkTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsSmartGateLink(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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