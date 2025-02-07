namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class BalancesFactory : IFactory<Balances>
{
    public static string DefaultQuery => "SELECT \"account\", \"value\" FROM erc721charactr__Balances;";

    public Balances FromJsonNode(JsonNode node, JsonArray headers) => new Balances
    {
        Account = node.GetValueFor<string>("Account", headers),
        Value = node.GetValueFor<string>("Value", headers)
    };
}