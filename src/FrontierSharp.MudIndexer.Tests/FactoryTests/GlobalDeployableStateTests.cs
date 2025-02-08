using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class GlobalDeployableStateTests
{
    private readonly ITestOutputHelper _output;
    public GlobalDeployableStateTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(GlobalDeployableStateTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsGlobalDeployableState(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new GlobalDeployableStateFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class GlobalDeployableStateTestData : FactoryTestData
    {
        public GlobalDeployableStateTestData()
        {
            SetDataFile("GlobalDeployableState.json");
        }
    }
}