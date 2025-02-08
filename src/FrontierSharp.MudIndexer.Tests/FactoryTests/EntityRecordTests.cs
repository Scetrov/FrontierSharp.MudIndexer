using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EntityRecordTests
{
    private readonly ITestOutputHelper _output;
    public EntityRecordTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(EntityRecordTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEntityRecord(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new EntityRecordFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EntityRecordTestData : FactoryTestData
    {
        public EntityRecordTestData()
        {
            SetDataFile("EntityRecord.json");
        }
    }
}