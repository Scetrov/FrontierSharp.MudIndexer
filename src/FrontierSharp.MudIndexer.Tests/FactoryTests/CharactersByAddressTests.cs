using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class CharactersByAddressTests
{
    [Theory, ClassData(typeof(CharactersByAddressTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsCharactersByAddress(JsonNode row, JsonArray headers, string data)
    {
        var factory = new CharactersByAddressFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class CharactersByAddressTestData : FactoryTestData
    {
        public CharactersByAddressTestData()
        {
            SetDataFile("CharactersByAddress.json");
        }
    }
}