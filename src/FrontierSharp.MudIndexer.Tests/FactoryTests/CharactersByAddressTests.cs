using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class CharactersByAddressTests
{
    private readonly ITestOutputHelper _output;
    public CharactersByAddressTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(CharactersByAddressTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsCharactersByAddress(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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