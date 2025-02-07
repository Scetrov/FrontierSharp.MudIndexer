namespace FrontierSharp.MudIndexer.Tables;
public class StoreHooks {
    public required byte[] TableId { get; set; }
    public required IEnumerable<byte[]> Hooks { get; set; }
}