using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Factories;
using Shouldly;
using Xunit;

namespace FrontierSharp.MudIndexer.Tests.FactoryTests;
public class TokenApprovalTests
{
    [Theory, ClassData(typeof(TokenApprovalTestData))]
    public void FromJsonNode_WithValidJsonNode_ReturnsTokenApproval(JsonNode row, JsonArray headers, string data)
    {
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