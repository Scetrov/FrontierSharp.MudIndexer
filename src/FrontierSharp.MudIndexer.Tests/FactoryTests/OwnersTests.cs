using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class OwnersTests
{
    [Theory, ClassData(typeof(OwnersTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsOwners(JsonNode row, JsonArray headers, string data)
    {
        var factory = new OwnersFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class OwnersTestData : FactoryTestData
    {
        public OwnersTestData()
        {
            SetDataFile("Owners.json");
        }
    }
}