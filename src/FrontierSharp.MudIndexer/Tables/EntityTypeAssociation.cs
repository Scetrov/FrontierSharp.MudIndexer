namespace FrontierSharp.MudIndexer.Tables;
public class EntityTypeAssociation {
    public required byte EntityType { get; set; }
    public required byte TaggedEntityType { get; set; }
    public required bool IsAllowed { get; set; }
}