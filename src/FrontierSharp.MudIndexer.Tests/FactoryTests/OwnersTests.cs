using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class OwnersTests
{
    private readonly ITestOutputHelper _output;
    public OwnersTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(OwnersTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsOwners(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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