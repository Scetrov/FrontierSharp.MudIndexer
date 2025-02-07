namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EntityTypeFactory : IFactory<EntityType>
{
    public static string DefaultQuery => "SELECT \"typeId\", \"doesExists\", \"typeName\" FROM eveworld__EntityType;";

    public EntityType FromJsonNode(JsonNode node, JsonArray headers) => new EntityType
    {
        TypeId = node.GetValueFor<byte>("TypeId", headers),
        DoesExists = node.GetValueFor<bool>("DoesExists", headers),
        TypeName = node.GetValueFor<byte[]>("TypeName", headers)
    };
}