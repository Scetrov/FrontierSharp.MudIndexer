namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class TokenApprovalFactory : IFactory<TokenApproval>
{
    public static string DefaultQuery => "SELECT \"tokenId\", \"account\" FROM erc721charactr__TokenApproval;";

    public TokenApproval FromJsonNode(JsonNode node, JsonArray headers) => new TokenApproval
    {
        TokenId = node.GetValueFor<string>("TokenId", headers),
        Account = node.GetValueFor<string>("Account", headers)
    };
}