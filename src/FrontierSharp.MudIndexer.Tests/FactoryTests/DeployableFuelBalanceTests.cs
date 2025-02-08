using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class DeployableFuelBalanceTests
{
    private readonly ITestOutputHelper _output;
    public DeployableFuelBalanceTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(DeployableFuelBalanceTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsDeployableFuelBalance(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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