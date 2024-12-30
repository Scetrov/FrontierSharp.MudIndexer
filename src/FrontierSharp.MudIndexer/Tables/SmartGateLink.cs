namespace FrontierSharp.MudIndexer.Tables;
public class SmartGateLink {
    public required string SourceGateId { get; set; }
    public required string DestinationGateId { get; set; }
    public required bool IsLinked { get; set; }
}