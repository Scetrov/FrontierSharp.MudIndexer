using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class StaticDataGlobalTests
{
    private readonly ITestOutputHelper _output;
    public StaticDataGlobalTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(StaticDataGlobalTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsStaticDataGlobal(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new StaticDataGlobalFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class StaticDataGlobalTestData : FactoryTestData
    {
        public StaticDataGlobalTestData()
        {
            SetDataFile("StaticDataGlobal.json");
        }
    }
}