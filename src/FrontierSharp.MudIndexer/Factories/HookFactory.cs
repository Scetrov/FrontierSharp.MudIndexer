namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class HookFactory : IFactory<Hook>
{
    public static string DefaultQuery => "SELECT \"hookId\", \"isHook\", \"systemId\", \"functionSelector\" FROM eveworld__HookTable;";

    public Hook FromJsonNode(JsonNode node, JsonArray headers) => new Hook
    {
        HookId = node.GetValueFor<string>("HookId", headers),
        IsHook = node.GetValueFor<bool>("IsHook", headers),
        SystemId = node.GetValueFor<byte[]>("SystemId", headers),
        FunctionSelector = node.GetValueFor<byte[]>("FunctionSelector", headers)
    };
}