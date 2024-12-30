using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class DeployableFuelBalanceTests
{
    [Theory, ClassData(typeof(DeployableFuelBalanceTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsDeployableFuelBalance(JsonNode row, JsonArray headers, string data)
    {
        var factory = new DeployableFuelBalanceFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class DeployableFuelBalanceTestData : FactoryTestData
    {
        public DeployableFuelBalanceTestData()
        {
            SetDataFile("DeployableFuelBalance.json");
        }
    }
}