namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class ItemTransferFactory : IFactory<ItemTransfer>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"inventoryItemId\", \"previousOwner\", \"currentOwner\", \"quantity\", \"updatedAt\" FROM eveworld__ItemTransferOffc;";

    public ItemTransfer FromJsonNode(JsonNode node, JsonArray headers) => new ItemTransfer
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        InventoryItemId = node.GetValueFor<string>("InventoryItemId", headers),
        PreviousOwner = node.GetValueFor<string>("PreviousOwner", headers),
        CurrentOwner = node.GetValueFor<string>("CurrentOwner", headers),
        Quantity = node.GetValueFor<string>("Quantity", headers),
        UpdatedAt = node.GetValueFor<DateTimeOffset>("UpdatedAt", headers)
    };
}