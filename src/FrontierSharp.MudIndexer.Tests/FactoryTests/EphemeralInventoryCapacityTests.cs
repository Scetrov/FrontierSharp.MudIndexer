using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class EphemeralInventoryCapacityTests
{
    [Theory, ClassData(typeof(EphemeralInventoryCapacityTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsEphemeralInventoryCapacity(JsonNode row, JsonArray headers, string data)
    {
        var factory = new EphemeralInventoryCapacityFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class EphemeralInventoryCapacityTestData : FactoryTestData
    {
        public EphemeralInventoryCapacityTestData()
        {
            SetDataFile("EphemeralInventoryCapacity.json");
        }
    }
}