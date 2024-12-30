namespace FrontierSharp.MudIndexer.Tables;
public class EntityRecord {
    public required string EntityId { get; set; }
    public required string ItemId { get; set; }
    public required string TypeId { get; set; }
    public required string Volume { get; set; }
    public required bool RecordExists { get; set; }
}