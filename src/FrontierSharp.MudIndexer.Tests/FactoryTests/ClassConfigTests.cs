using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class ClassConfigTests
{
    [Theory, ClassData(typeof(ClassConfigTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsClassConfig(JsonNode row, JsonArray headers, string data)
    {
        var factory = new ClassConfigFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class ClassConfigTestData : FactoryTestData
    {
        public ClassConfigTestData()
        {
            SetDataFile("ClassConfig.json");
        }
    }
}