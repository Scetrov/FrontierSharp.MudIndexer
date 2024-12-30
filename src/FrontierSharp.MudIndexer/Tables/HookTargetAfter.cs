namespace FrontierSharp.MudIndexer.Tables;
public class HookTargetAfter {
    public required string HookId { get; set; }
    public required string TargetId { get; set; }
    public required bool HasHook { get; set; }
    public required byte[] SystemSelector { get; set; }
    public required byte[] FunctionSelector { get; set; }
}