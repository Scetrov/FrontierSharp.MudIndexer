namespace FrontierSharp.MudIndexer.Tables;
public class AccessRole {
    public required byte[] RoleId { get; set; }
    public required IEnumerable<string> Accounts { get; set; }
}