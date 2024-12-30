using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class SmartAssemblyTests
{
    [Theory, ClassData(typeof(SmartAssemblyTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsSmartAssembly(JsonNode row, JsonArray headers, string data)
    {
        var factory = new SmartAssemblyFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class SmartAssemblyTestData : FactoryTestData
    {
        public SmartAssemblyTestData()
        {
            SetDataFile("SmartAssembly.json");
        }
    }
}