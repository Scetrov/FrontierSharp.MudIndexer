namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class CharactersByAddressFactory : IFactory<CharactersByAddress>
{
    public static string DefaultQuery => "SELECT \"characterAddress\", \"characterId\" FROM eveworld__CharactersByAddr;";

    public CharactersByAddress FromJsonNode(JsonNode node, JsonArray headers) => new CharactersByAddress
    {
        CharacterAddress = node.GetValueFor<string>("CharacterAddress", headers),
        CharacterId = node.GetValueFor<string>("CharacterId", headers)
    };
}