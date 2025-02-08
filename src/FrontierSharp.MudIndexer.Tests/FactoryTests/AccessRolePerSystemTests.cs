using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class AccessRolePerSystemTests
{
    private readonly ITestOutputHelper _output;
    public AccessRolePerSystemTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(AccessRolePerSystemTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsAccessRolePerSystem(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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