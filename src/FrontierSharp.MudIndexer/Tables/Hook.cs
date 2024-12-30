namespace FrontierSharp.MudIndexer.Tables;
public class Hook {
    public required string HookId { get; set; }
    public required bool IsHook { get; set; }
    public required byte[] SystemId { get; set; }
    public required byte[] FunctionSelector { get; set; }
}