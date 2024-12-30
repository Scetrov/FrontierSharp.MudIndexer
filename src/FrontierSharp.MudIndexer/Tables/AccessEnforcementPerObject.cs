namespace FrontierSharp.MudIndexer.Tables;
public class AccessEnforcementPerObject {
    public required string SmartObjectId { get; set; }
    public required byte[] Target { get; set; }
    public required bool IsEnforced { get; set; }
}