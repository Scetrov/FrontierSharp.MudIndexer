namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class CharactersConstantsFactory
{
    public static string DefaultQuery => "SELECT \"erc721Address\" FROM eveworld__CharactersConsta;";

    public CharactersConstants FromJsonNode(JsonNode node, JsonArray headers) => new CharactersConstants
    {
        Erc721Address = node.GetValueFor<string>("Erc721Address", headers)
    };
}