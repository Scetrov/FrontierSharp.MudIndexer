using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class CharacterTests
{
    [Theory, ClassData(typeof(CharacterTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsCharacter(JsonNode row, JsonArray headers, string data)
    {
        var factory = new CharacterFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class CharacterTestData : FactoryTestData
    {
        public CharacterTestData()
        {
            SetDataFile("Character.json");
        }
    }
}