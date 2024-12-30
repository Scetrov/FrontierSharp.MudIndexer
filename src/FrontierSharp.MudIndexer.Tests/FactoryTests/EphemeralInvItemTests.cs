using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EphemeralInvItemTests
{
    [Theory, ClassData(typeof(EphemeralInvItemTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEphemeralInvItem(JsonNode row, JsonArray headers, string data)
    {
        var factory = new EphemeralInvItemFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EphemeralInvItemTestData : FactoryTestData
    {
        public EphemeralInvItemTestData()
        {
            SetDataFile("EphemeralInvItem.json");
        }
    }
}