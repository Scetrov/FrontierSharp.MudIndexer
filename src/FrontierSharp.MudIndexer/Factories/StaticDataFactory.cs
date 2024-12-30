namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class StaticDataFactory
{
    public static string DefaultQuery => "SELECT \"entityId\", \"cid\" FROM eveworld__StaticDataTable;";

    public StaticData FromJsonNode(JsonNode node, JsonArray headers) => new StaticData
    {
        EntityId = node.GetValueFor<string>("EntityId", headers),
        Cid = node.GetValueFor<string>("Cid", headers)
    };
}