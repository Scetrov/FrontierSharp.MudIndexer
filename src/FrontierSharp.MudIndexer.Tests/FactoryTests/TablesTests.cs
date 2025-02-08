using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class TablesTests
{
    private readonly ITestOutputHelper _output;
    public TablesTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(TablesTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsTables(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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