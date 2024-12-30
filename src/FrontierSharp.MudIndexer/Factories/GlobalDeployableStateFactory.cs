namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class GlobalDeployableStateFactory
{
    public static string DefaultQuery => "SELECT \"updatedBlockNumber\", \"isPaused\", \"lastGlobalOffline\", \"lastGlobalOnline\" FROM eveworld__GlobalDeployable;";

    public GlobalDeployableState FromJsonNode(JsonNode node, JsonArray headers) => new GlobalDeployableState
    {
        UpdatedBlockNumber = node.GetValueFor<string>("UpdatedBlockNumber", headers),
        IsPaused = node.GetValueFor<bool>("IsPaused", headers),
        LastGlobalOffline = node.GetValueFor<string>("LastGlobalOffline", headers),
        LastGlobalOnline = node.GetValueFor<string>("LastGlobalOnline", headers)
    };
}