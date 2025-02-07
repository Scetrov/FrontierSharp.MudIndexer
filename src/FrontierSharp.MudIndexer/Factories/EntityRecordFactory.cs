namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EntityRecordFactory : IFactory<EntityRecord>
{
    public static string DefaultQuery => "SELECT \"entityId\", \"itemId\", \"typeId\", \"volume\", \"recordExists\" FROM eveworld__EntityRecordTabl;";

    public EntityRecord FromJsonNode(JsonNode node, JsonArray headers) => new EntityRecord
    {
        EntityId = node.GetValueFor<string>("EntityId", headers),
        ItemId = node.GetValueFor<string>("ItemId", headers),
        TypeId = node.GetValueFor<string>("TypeId", headers),
        Volume = node.GetValueFor<string>("Volume", headers),
        RecordExists = node.GetValueFor<bool>("RecordExists", headers)
    };
}