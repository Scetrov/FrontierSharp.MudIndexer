using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class GlobalStaticDataTests
{
    private readonly ITestOutputHelper _output;
    public GlobalStaticDataTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(GlobalStaticDataTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsGlobalStaticData(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new GlobalStaticDataFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class GlobalStaticDataTestData : FactoryTestData
    {
        public GlobalStaticDataTestData()
        {
            SetDataFile("GlobalStaticData.json");
        }
    }
}