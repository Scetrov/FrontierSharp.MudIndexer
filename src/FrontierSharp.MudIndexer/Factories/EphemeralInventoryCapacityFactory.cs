namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EphemeralInventoryCapacityFactory : IFactory<EphemeralInventoryCapacity>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"capacity\" FROM eveworld__EphemeralInvCapa;";

    public EphemeralInventoryCapacity FromJsonNode(JsonNode node, JsonArray headers) => new EphemeralInventoryCapacity
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        Capacity = node.GetValueFor<string>("Capacity", headers)
    };
}