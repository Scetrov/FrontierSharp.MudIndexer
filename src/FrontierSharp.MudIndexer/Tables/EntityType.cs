namespace FrontierSharp.MudIndexer.Tables;
public class EntityType {
    public required byte TypeId { get; set; }
    public required bool DoesExists { get; set; }
    public required byte[] TypeName { get; set; }
}