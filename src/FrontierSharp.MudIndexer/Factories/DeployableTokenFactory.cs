namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class DeployableTokenFactory : IFactory<DeployableToken>
{
    public static string DefaultQuery => "SELECT \"erc721Address\" FROM eveworld__DeployableTokenT;";

    public DeployableToken FromJsonNode(JsonNode node, JsonArray headers) => new DeployableToken
    {
        Erc721Address = node.GetValueFor<string>("Erc721Address", headers)
    };
}