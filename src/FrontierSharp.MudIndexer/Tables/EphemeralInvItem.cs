namespace FrontierSharp.MudIndexer.Tables;
public class EphemeralInvItem {
    public required string SmartObjectId { get; set; }
    public required string InventoryItemId { get; set; }
    public required string EphemeralInvOwner { get; set; }
    public required string Quantity { get; set; }
    public required string Index { get; set; }
}