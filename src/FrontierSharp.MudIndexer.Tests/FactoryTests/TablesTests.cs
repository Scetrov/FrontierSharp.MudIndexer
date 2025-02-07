using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class TablesTests
{
    [Theory, ClassData(typeof(TablesTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsTables(JsonNode row, JsonArray headers, string data)
    {
        var factory = new TablesFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class TablesTestData : FactoryTestData
    {
        public TablesTestData()
        {
            SetDataFile("Tables.json");
        }
    }
}