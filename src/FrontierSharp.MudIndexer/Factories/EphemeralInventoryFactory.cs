namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EphemeralInventoryFactory : IFactory<EphemeralInventory>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"ephemeralInvOwner\", \"usedCapacity\" FROM eveworld__EphemeralInvTabl;";

    public EphemeralInventory FromJsonNode(JsonNode node, JsonArray headers) => new EphemeralInventory
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        EphemeralInvOwner = node.GetValueFor<string>("EphemeralInvOwner", headers),
        UsedCapacity = node.GetValueFor<string>("UsedCapacity", headers)
    };
}