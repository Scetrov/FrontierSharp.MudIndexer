namespace FrontierSharp.MudIndexer.Tables;
public class EntityAssociation {
    public required string EntityId { get; set; }
    public required IEnumerable<string> ModuleIds { get; set; }
    public required IEnumerable<string> HookIds { get; set; }
}