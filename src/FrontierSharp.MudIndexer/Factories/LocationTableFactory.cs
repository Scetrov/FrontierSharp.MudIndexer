namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class LocationTableFactory : IFactory<LocationTable>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"solarSystemId\", \"x\", \"y\", \"z\" FROM eveworld__LocationTable;";

    public LocationTable FromJsonNode(JsonNode node, JsonArray headers) => new LocationTable
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        SolarSystemId = node.GetValueFor<string>("SolarSystemId", headers),
        X = node.GetValueFor<string>("X", headers),
        Y = node.GetValueFor<string>("Y", headers),
        Z = node.GetValueFor<string>("Z", headers)
    };
}