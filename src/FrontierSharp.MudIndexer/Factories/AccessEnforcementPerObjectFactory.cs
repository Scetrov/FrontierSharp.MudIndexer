namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class AccessEnforcementPerObjectFactory : IFactory<AccessEnforcementPerObject>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"target\", \"isEnforced\" FROM eveworld__AccessEnforcePer;";

    public AccessEnforcementPerObject FromJsonNode(JsonNode node, JsonArray headers) => new AccessEnforcementPerObject
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        Target = node.GetValueFor<byte[]>("Target", headers),
        IsEnforced = node.GetValueFor<bool>("IsEnforced", headers)
    };
}