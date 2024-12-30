namespace FrontierSharp.MudIndexer.Tables;
public class ModuleSystemLookup {
    public required string ModuleId { get; set; }
    public required IEnumerable<byte[]> SystemIds { get; set; }
}