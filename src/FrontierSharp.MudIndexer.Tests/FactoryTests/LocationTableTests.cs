using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class LocationTableTests
{
    private readonly ITestOutputHelper _output;
    public LocationTableTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(LocationTableTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsLocationTable(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new LocationTableFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class LocationTableTestData : FactoryTestData
    {
        public LocationTableTestData()
        {
            SetDataFile("LocationTable.json");
        }
    }
}