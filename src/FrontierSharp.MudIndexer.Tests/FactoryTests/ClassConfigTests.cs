using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class ClassConfigTests
{
    private readonly ITestOutputHelper _output;
    public ClassConfigTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(ClassConfigTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsClassConfig(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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