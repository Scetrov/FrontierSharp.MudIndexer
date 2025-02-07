namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class SmartGateConfigFactory : IFactory<SmartGateConfig>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"systemId\" FROM eveworld__SmartGateConfigT;";

    public SmartGateConfig FromJsonNode(JsonNode node, JsonArray headers) => new SmartGateConfig
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        SystemId = node.GetValueFor<byte[]>("SystemId", headers)
    };
}