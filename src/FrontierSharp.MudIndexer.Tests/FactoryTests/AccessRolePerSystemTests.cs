using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class AccessRolePerSystemTests
{
    [Theory, ClassData(typeof(AccessRolePerSystemTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsAccessRolePerSystem(JsonNode row, JsonArray headers, string data)
    {
        var factory = new AccessRolePerSystemFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class AccessRolePerSystemTestData : FactoryTestData
    {
        public AccessRolePerSystemTestData()
        {
            SetDataFile("AccessRolePerSystem.json");
        }
    }
}