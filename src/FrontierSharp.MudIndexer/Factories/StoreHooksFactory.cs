namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class StoreHooksFactory : IFactory<StoreHooks>
{
    public static string DefaultQuery => "SELECT \"tableId\", \"hooks\" FROM store__StoreHooks;";

    public StoreHooks FromJsonNode(JsonNode node, JsonArray headers) => new StoreHooks
    {
        TableId = node.GetValueFor<byte[]>("TableId", headers),
        Hooks = node.GetValueFor<IEnumerable<byte[]>>("Hooks", headers)
    };
}