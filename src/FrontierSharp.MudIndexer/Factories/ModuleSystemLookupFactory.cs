namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class ModuleSystemLookupFactory
{
    public static string DefaultQuery => "SELECT \"moduleId\", \"systemIds\" FROM eveworld__ModuleSystemLook;";

    public ModuleSystemLookup FromJsonNode(JsonNode node, JsonArray headers) => new ModuleSystemLookup
    {
        ModuleId = node.GetValueFor<string>("ModuleId", headers),
        SystemIds = node.GetValueFor<IEnumerable<byte[]>>("SystemIds", headers)
    };
}