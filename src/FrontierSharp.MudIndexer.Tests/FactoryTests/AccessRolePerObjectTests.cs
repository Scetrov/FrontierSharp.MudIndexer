using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class AccessRolePerObjectTests
{
    [Theory, ClassData(typeof(AccessRolePerObjectTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsAccessRolePerObject(JsonNode row, JsonArray headers, string data)
    {
        var factory = new AccessRolePerObjectFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class AccessRolePerObjectTestData : FactoryTestData
    {
        public AccessRolePerObjectTestData()
        {
            SetDataFile("AccessRolePerObject.json");
        }
    }
}