namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EntityFactory
{
    public static string DefaultQuery => "SELECT \"entityId\", \"doesExists\", \"entityType\" FROM eveworld__EntityTable;";

    public Entity FromJsonNode(JsonNode node, JsonArray headers) => new Entity
    {
        EntityId = node.GetValueFor<string>("EntityId", headers),
        DoesExists = node.GetValueFor<bool>("DoesExists", headers),
        EntityType = node.GetValueFor<byte>("EntityType", headers)
    };
}