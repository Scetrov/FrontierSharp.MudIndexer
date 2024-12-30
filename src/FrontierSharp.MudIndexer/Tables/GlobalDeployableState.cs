namespace FrontierSharp.MudIndexer.Tables;
public class GlobalDeployableState {
    public required string UpdatedBlockNumber { get; set; }
    public required bool IsPaused { get; set; }
    public required string LastGlobalOffline { get; set; }
    public required string LastGlobalOnline { get; set; }
}