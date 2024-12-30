namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class InventoryItemFactory
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"inventoryItemId\", \"quantity\", \"index\" FROM eveworld__InventoryItemTab;";

    public InventoryItem FromJsonNode(JsonNode node, JsonArray headers) => new InventoryItem
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        InventoryItemId = node.GetValueFor<string>("InventoryItemId", headers),
        Quantity = node.GetValueFor<string>("Quantity", headers),
        Index = node.GetValueFor<string>("Index", headers)
    };
}