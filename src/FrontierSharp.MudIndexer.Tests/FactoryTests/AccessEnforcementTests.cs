using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class AccessEnforcementTests
{
    [Theory, ClassData(typeof(AccessEnforcementTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsAccessEnforcement(JsonNode row, JsonArray headers, string data)
    {
        var factory = new AccessEnforcementFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class AccessEnforcementTestData : FactoryTestData
    {
        public AccessEnforcementTestData()
        {
            SetDataFile("AccessEnforcement.json");
        }
    }
}