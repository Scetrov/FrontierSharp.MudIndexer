using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class AccessRoleTests
{
    [Theory, ClassData(typeof(AccessRoleTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsAccessRole(JsonNode row, JsonArray headers, string data)
    {
        var factory = new AccessRoleFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class AccessRoleTestData : FactoryTestData
    {
        public AccessRoleTestData()
        {
            SetDataFile("AccessRole.json");
        }
    }
}