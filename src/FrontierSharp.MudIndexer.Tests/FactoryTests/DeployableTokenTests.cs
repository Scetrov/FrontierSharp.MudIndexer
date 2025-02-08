using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class DeployableTokenTests
{
    private readonly ITestOutputHelper _output;
    public DeployableTokenTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(DeployableTokenTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsDeployableToken(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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