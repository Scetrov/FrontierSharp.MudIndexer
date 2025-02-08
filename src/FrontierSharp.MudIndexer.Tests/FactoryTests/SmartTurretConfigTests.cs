using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class SmartTurretConfigTests
{
    private readonly ITestOutputHelper _output;
    public SmartTurretConfigTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(SmartTurretConfigTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsSmartTurretConfig(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new SmartTurretConfigFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class SmartTurretConfigTestData : FactoryTestData
    {
        public SmartTurretConfigTestData()
        {
            SetDataFile("SmartTurretConfig.json");
        }
    }
}