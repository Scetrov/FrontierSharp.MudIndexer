namespace FrontierSharp.MudIndexer.Tables;
public class AccessRolePerSystem {
    public required byte[] SystemId { get; set; }
    public required byte[] RoleId { get; set; }
    public required IEnumerable<string> Accounts { get; set; }
}