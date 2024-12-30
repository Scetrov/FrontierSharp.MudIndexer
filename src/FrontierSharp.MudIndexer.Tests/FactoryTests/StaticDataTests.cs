using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class StaticDataTests
{
    [Theory, ClassData(typeof(StaticDataTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsStaticData(JsonNode row, JsonArray headers, string data)
    {
        var factory = new StaticDataFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class StaticDataTestData : FactoryTestData
    {
        public StaticDataTestData()
        {
            SetDataFile("StaticData.json");
        }
    }
}