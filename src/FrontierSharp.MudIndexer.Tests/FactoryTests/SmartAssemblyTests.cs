using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class SmartAssemblyTests
{
    private readonly ITestOutputHelper _output;
    public SmartAssemblyTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(SmartAssemblyTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsSmartAssembly(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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