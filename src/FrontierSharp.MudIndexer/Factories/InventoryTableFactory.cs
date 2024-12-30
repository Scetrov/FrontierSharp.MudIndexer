namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class InventoryTableFactory
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"capacity\" FROM eveworld__InventoryTable;";

    public InventoryTable FromJsonNode(JsonNode node, JsonArray headers) => new InventoryTable
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        Capacity = node.GetValueFor<string>("Capacity", headers)
    };
}