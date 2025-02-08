namespace FrontierSharp.MudIndexer.Tables;
public class DeployableState {
    public required string SmartObjectId { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required byte PreviousState { get; set; }
    public required byte CurrentState { get; set; }
    public required bool IsValid { get; set; }
    public required DateTimeOffset AnchoredAt { get; set; }
    public required string UpdatedBlockNumber { get; set; }
    public required DateTimeOffset UpdatedBlockTime { get; set; }
}