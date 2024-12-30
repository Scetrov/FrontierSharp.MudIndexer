using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class GlobalStaticDataTests
{
    [Theory, ClassData(typeof(GlobalStaticDataTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsGlobalStaticData(JsonNode row, JsonArray headers, string data)
    {
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