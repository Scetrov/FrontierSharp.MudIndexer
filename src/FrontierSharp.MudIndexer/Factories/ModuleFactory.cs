namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class ModuleFactory
{
    public static string DefaultQuery => "SELECT \"moduleId\", \"systemId\", \"moduleName\", \"doesExists\" FROM eveworld__ModuleTable;";

    public Module FromJsonNode(JsonNode node, JsonArray headers) => new Module
    {
        ModuleId = node.GetValueFor<string>("ModuleId", headers),
        SystemId = node.GetValueFor<byte[]>("SystemId", headers),
        ModuleName = node.GetValueFor<byte[]>("ModuleName", headers),
        DoesExists = node.GetValueFor<bool>("DoesExists", headers)
    };
}