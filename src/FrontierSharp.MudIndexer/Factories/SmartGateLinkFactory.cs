namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class SmartGateLinkFactory : IFactory<SmartGateLink>
{
    public static string DefaultQuery => "SELECT \"sourceGateId\", \"destinationGateId\", \"isLinked\" FROM eveworld__SmartGateLinkTab;";

    public SmartGateLink FromJsonNode(JsonNode node, JsonArray headers) => new SmartGateLink
    {
        SourceGateId = node.GetValueFor<string>("SourceGateId", headers),
        DestinationGateId = node.GetValueFor<string>("DestinationGateId", headers),
        IsLinked = node.GetValueFor<bool>("IsLinked", headers)
    };
}