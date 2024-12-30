using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class StaticDataGlobalTests
{
    [Theory, ClassData(typeof(StaticDataGlobalTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsStaticDataGlobal(JsonNode row, JsonArray headers, string data)
    {
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