namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class CharacterFactory : IFactory<Character>
{
    public static string DefaultQuery => "SELECT \"characterId\", \"characterAddress\", \"corpId\", \"createdAt\" FROM eveworld__CharactersTable;";

    public Character FromJsonNode(JsonNode node, JsonArray headers) => new Character
    {
        CharacterId = node.GetValueFor<string>("CharacterId", headers),
        CharacterAddress = node.GetValueFor<string>("CharacterAddress", headers),
        CorpId = node.GetValueFor<string>("CorpId", headers),
        CreatedAt = node.GetValueFor<DateTimeOffset>("CreatedAt", headers)
    };
}