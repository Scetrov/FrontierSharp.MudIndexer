namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EntityMapFactory : IFactory<EntityMap>
{
    public static string DefaultQuery => "SELECT \"entityId\", \"taggedEntityIds\" FROM eveworld__EntityMap;";

    public EntityMap FromJsonNode(JsonNode node, JsonArray headers) => new EntityMap
    {
        EntityId = node.GetValueFor<string>("EntityId", headers),
        TaggedEntityIds = node.GetValueFor<IEnumerable<string>>("TaggedEntityIds", headers)
    };
}