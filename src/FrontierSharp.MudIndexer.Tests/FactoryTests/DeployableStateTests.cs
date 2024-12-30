using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class DeployableStateTests
{
    [Theory, ClassData(typeof(DeployableStateTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsDeployableState(JsonNode row, JsonArray headers, string data)
    {
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