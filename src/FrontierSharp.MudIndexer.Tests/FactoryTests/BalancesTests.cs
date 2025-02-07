using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class BalancesTests
{
    [Theory, ClassData(typeof(BalancesTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsBalances(JsonNode row, JsonArray headers, string data)
    {
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