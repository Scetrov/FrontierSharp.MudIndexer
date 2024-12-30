using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class DeployableTokenTests
{
    [Theory, ClassData(typeof(DeployableTokenTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsDeployableToken(JsonNode row, JsonArray headers, string data)
    {
        var factory = new DeployableTokenFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class DeployableTokenTestData : FactoryTestData
    {
        public DeployableTokenTestData()
        {
            SetDataFile("DeployableToken.json");
        }
    }
}