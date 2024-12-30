namespace FrontierSharp.MudIndexer.Tables;
public class AccessEnforcement {
    public required byte[] Target { get; set; }
    public required bool IsEnforced { get; set; }
}