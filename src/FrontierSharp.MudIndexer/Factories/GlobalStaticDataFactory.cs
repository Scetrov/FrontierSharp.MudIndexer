namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class GlobalStaticDataFactory
{
    public static string DefaultQuery => "SELECT \"trustedForwarder\", \"value\" FROM eveworld__GlobalStaticData;";

    public GlobalStaticData FromJsonNode(JsonNode node, JsonArray headers) => new GlobalStaticData
    {
        TrustedForwarder = node.GetValueFor<string>("TrustedForwarder", headers),
        Value = node.GetValueFor<bool>("Value", headers)
    };
}