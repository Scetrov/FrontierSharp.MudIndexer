using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class GlobalDeployableStateTests
{
    [Theory, ClassData(typeof(GlobalDeployableStateTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsGlobalDeployableState(JsonNode row, JsonArray headers, string data)
    {
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