namespace FrontierSharp.MudIndexer.Tables;
public class AccessRolePerObject {
    public required string SmartObjectId { get; set; }
    public required byte[] RoleId { get; set; }
    public required IEnumerable<string> Accounts { get; set; }
}