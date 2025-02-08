using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class TokenApprovalTests
{
    private readonly ITestOutputHelper _output;
    public TokenApprovalTests(ITestOutputHelper output)
    {
        this._output = output;
    }

    [Theory, ClassData(typeof(TokenApprovalTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsTokenApproval(JsonNode row, JsonArray headers, string data)
    {
        _output.WriteLine(data);
        var factory = new TokenApprovalFactory();
        var node = Should.NotThrow(() => factory.FromJsonNode(row, headers));
        node.ShouldNotBeNull();
    }

    private class TokenApprovalTestData : FactoryTestData
    {
        public TokenApprovalTestData()
        {
            SetDataFile("TokenApproval.json");
        }
    }
}