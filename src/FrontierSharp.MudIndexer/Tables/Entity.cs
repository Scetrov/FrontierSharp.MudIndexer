namespace FrontierSharp.MudIndexer.Tables;
public class Entity {
    public required string EntityId { get; set; }
    public required bool DoesExists { get; set; }
    public required byte EntityType { get; set; }
}