namespace FrontierSharp.MudIndexer.Tables;
public class KillMailTable {
    public required string KillMailId { get; set; }
    public required string KillerCharacterId { get; set; }
    public required string VictimCharacterId { get; set; }
    public required byte LossType { get; set; }
    public required string SolarSystemId { get; set; }
    public required string KillTimestamp { get; set; }
}