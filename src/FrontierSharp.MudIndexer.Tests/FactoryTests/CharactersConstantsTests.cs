using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class CharactersConstantsTests
{
    private readonly ITestOutputHelper _output;
    public CharactersConstantsTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(CharactersConstantsTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsCharactersConstants(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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