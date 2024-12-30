namespace FrontierSharp.MudIndexer.Tables;
public class ItemTransfer {
    public required string SmartObjectId { get; set; }
    public required string InventoryItemId { get; set; }
    public required string PreviousOwner { get; set; }
    public required string CurrentOwner { get; set; }
    public required string Quantity { get; set; }
    public required string UpdatedAt { get; set; }
}