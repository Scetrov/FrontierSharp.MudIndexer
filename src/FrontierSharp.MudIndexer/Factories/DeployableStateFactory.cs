namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class DeployableStateFactory : IFactory<DeployableState>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"createdAt\", \"previousState\", \"currentState\", \"isValid\", \"anchoredAt\", \"updatedBlockNumber\", \"updatedBlockTime\" FROM eveworld__DeployableState;";

    public DeployableState FromJsonNode(JsonNode node, JsonArray headers) => new DeployableState
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        CreatedAt = node.GetValueFor<DateTimeOffset>("CreatedAt", headers),
        PreviousState = node.GetValueFor<byte>("PreviousState", headers),
        CurrentState = node.GetValueFor<byte>("CurrentState", headers),
        IsValid = node.GetValueFor<bool>("IsValid", headers),
        AnchoredAt = node.GetValueFor<DateTimeOffset>("AnchoredAt", headers),
        UpdatedBlockNumber = node.GetValueFor<string>("UpdatedBlockNumber", headers),
        UpdatedBlockTime = node.GetValueFor<DateTimeOffset>("UpdatedBlockTime", headers)
    };
}