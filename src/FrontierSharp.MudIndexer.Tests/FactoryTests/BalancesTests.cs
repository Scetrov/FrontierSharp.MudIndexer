using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class BalancesTests
{
    private readonly ITestOutputHelper _output;
    public BalancesTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(BalancesTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsBalances(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new BalancesFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class BalancesTestData : FactoryTestData
    {
        public BalancesTestData()
        {
            SetDataFile("Balances.json");
        }
    }
}