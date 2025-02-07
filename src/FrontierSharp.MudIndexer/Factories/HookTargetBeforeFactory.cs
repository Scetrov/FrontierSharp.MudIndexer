namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class HookTargetBeforeFactory : IFactory<HookTargetBefore>
{
    public static string DefaultQuery => "SELECT \"hookId\", \"targetId\", \"hasHook\", \"systemSelector\", \"functionSelector\" FROM eveworld__HookTargetBefore;";

    public HookTargetBefore FromJsonNode(JsonNode node, JsonArray headers) => new HookTargetBefore
    {
        HookId = node.GetValueFor<string>("HookId", headers),
        TargetId = node.GetValueFor<string>("TargetId", headers),
        HasHook = node.GetValueFor<bool>("HasHook", headers),
        SystemSelector = node.GetValueFor<byte[]>("SystemSelector", headers),
        FunctionSelector = node.GetValueFor<byte[]>("FunctionSelector", headers)
    };
}