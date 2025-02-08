using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class ResourceIdsTests
{
    private readonly ITestOutputHelper _output;
    public ResourceIdsTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(ResourceIdsTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsResourceIds(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new ResourceIdsFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class ResourceIdsTestData : FactoryTestData
    {
        public ResourceIdsTestData()
        {
            SetDataFile("ResourceIds.json");
        }
    }
}