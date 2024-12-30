using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class AccessEnforcementPerObjectTests
{
    [Theory, ClassData(typeof(AccessEnforcementPerObjectTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsAccessEnforcementPerObject(JsonNode row, JsonArray headers, string data)
    {
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