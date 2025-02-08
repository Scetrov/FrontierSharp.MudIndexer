using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class AccessRoleTests
{
    private readonly ITestOutputHelper _output;
    public AccessRoleTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(AccessRoleTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsAccessRole(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
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