using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EntityTests
{
    private readonly ITestOutputHelper _output;
    public EntityTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(EntityTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEntity(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new EntityFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EntityTestData : FactoryTestData
    {
        public EntityTestData()
        {
            SetDataFile("Entity.json");
        }
    }
}