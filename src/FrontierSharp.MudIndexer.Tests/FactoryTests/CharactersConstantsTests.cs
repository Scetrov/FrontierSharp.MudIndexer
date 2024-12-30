using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class CharactersConstantsTests
{
    [Theory, ClassData(typeof(CharactersConstantsTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsCharactersConstants(JsonNode row, JsonArray headers, string data)
    {
        var factory = new CharactersConstantsFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class CharactersConstantsTestData : FactoryTestData
    {
        public CharactersConstantsTestData()
        {
            SetDataFile("CharactersConstants.json");
        }
    }
}