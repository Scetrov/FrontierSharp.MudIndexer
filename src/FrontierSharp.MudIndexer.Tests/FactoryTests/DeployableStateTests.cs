using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class DeployableStateTests
{
    private readonly ITestOutputHelper _output;
    public DeployableStateTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(DeployableStateTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsDeployableState(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new DeployableStateFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class DeployableStateTestData : FactoryTestData
    {
        public DeployableStateTestData()
        {
            SetDataFile("DeployableState.json");
        }
    }
}