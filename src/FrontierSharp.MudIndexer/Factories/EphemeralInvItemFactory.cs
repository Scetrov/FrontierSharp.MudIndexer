namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EphemeralInvItemFactory : IFactory<EphemeralInvItem>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"inventoryItemId\", \"ephemeralInvOwner\", \"quantity\", \"index\" FROM eveworld__EphemeralInvItem;";

    public EphemeralInvItem FromJsonNode(JsonNode node, JsonArray headers) => new EphemeralInvItem
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        InventoryItemId = node.GetValueFor<string>("InventoryItemId", headers),
        EphemeralInvOwner = node.GetValueFor<string>("EphemeralInvOwner", headers),
        Quantity = node.GetValueFor<string>("Quantity", headers),
        Index = node.GetValueFor<string>("Index", headers)
    };
}