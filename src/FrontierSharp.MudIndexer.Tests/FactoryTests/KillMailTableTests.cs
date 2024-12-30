using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class KillMailTableTests
{
    [Theory, ClassData(typeof(KillMailTableTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsKillMailTable(JsonNode row, JsonArray headers, string data)
    {
        var factory = new KillMailTableFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class KillMailTableTestData : FactoryTestData
    {
        public KillMailTableTestData()
        {
            SetDataFile("KillMailTable.json");
        }
    }
}