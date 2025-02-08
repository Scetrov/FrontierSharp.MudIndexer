using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class KillMailTableTests
{
    private readonly ITestOutputHelper _output;
    public KillMailTableTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(KillMailTableTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsKillMailTable(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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