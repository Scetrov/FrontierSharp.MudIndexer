using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EntityMapTests
{
    private readonly ITestOutputHelper _output;
    public EntityMapTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(EntityMapTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEntityMap(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new EntityMapFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EntityMapTestData : FactoryTestData
    {
        public EntityMapTestData()
        {
            SetDataFile("EntityMap.json");
        }
    }
}