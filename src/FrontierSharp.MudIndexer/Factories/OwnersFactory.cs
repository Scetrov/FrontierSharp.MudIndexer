namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class OwnersFactory : IFactory<Owners>
{
    public static string DefaultQuery => "SELECT \"tokenId\", \"owner\" FROM erc721charactr__Owners;";

    public Owners FromJsonNode(JsonNode node, JsonArray headers) => new Owners
    {
        TokenId = node.GetValueFor<string>("TokenId", headers),
        Owner = node.GetValueFor<string>("Owner", headers)
    };
}