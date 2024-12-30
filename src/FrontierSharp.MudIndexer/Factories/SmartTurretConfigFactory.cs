namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class SmartTurretConfigFactory
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"systemId\" FROM eveworld__SmartTurretConfi;";

    public SmartTurretConfig FromJsonNode(JsonNode node, JsonArray headers) => new SmartTurretConfig
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        SystemId = node.GetValueFor<byte[]>("SystemId", headers)
    };
}