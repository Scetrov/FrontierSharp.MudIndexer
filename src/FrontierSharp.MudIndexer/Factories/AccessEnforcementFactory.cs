namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class AccessEnforcementFactory : IFactory<AccessEnforcement>
{
    public static string DefaultQuery => "SELECT \"target\", \"isEnforced\" FROM eveworld__AccessEnforcemen;";

    public AccessEnforcement FromJsonNode(JsonNode node, JsonArray headers) => new AccessEnforcement
    {
        Target = node.GetValueFor<byte[]>("Target", headers),
        IsEnforced = node.GetValueFor<bool>("IsEnforced", headers)
    };
}