namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class DeployableFuelBalanceFactory : IFactory<DeployableFuelBalance>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"fuelUnitVolume\", \"fuelConsumptionPerMinute\", \"fuelMaxCapacity\", \"fuelAmount\", \"lastUpdatedAt\" FROM eveworld__DeployableFuelBa;";

    public DeployableFuelBalance FromJsonNode(JsonNode node, JsonArray headers) => new DeployableFuelBalance
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        FuelUnitVolume = node.GetValueFor<string>("FuelUnitVolume", headers),
        FuelConsumptionPerMinute = node.GetValueFor<string>("FuelConsumptionPerMinute", headers),
        FuelMaxCapacity = node.GetValueFor<string>("FuelMaxCapacity", headers),
        FuelAmount = node.GetValueFor<string>("FuelAmount", headers),
        LastUpdatedAt = node.GetValueFor<DateTimeOffset>("LastUpdatedAt", headers)
    };
}