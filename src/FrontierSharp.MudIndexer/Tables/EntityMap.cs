namespace FrontierSharp.MudIndexer.Tables;
public class EntityMap {
    public required string EntityId { get; set; }
    public required IEnumerable<string> TaggedEntityIds { get; set; }
}