namespace FrontierSharp.MudIndexer.Tables;
public class DeployableFuelBalance {
    public required string SmartObjectId { get; set; }
    public required string FuelUnitVolume { get; set; }
    public required string FuelConsumptionPerMinute { get; set; }
    public required string FuelMaxCapacity { get; set; }
    public required string FuelAmount { get; set; }
    public required DateTimeOffset LastUpdatedAt { get; set; }
}