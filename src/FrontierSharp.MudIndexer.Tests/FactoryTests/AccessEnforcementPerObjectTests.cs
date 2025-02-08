using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class AccessEnforcementPerObjectTests
{
    private readonly ITestOutputHelper _output;
    public AccessEnforcementPerObjectTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(AccessEnforcementPerObjectTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsAccessEnforcementPerObject(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new AccessEnforcementPerObjectFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class AccessEnforcementPerObjectTestData : FactoryTestData
    {
        public AccessEnforcementPerObjectTestData()
        {
            SetDataFile("AccessEnforcementPerObject.json");
        }
    }
}