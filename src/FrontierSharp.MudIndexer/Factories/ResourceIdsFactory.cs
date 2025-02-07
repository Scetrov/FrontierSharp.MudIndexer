namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class ResourceIdsFactory : IFactory<ResourceIds>
{
    public static string DefaultQuery => "SELECT \"resourceId\", \"exists\" FROM store__ResourceIds;";

    public ResourceIds FromJsonNode(JsonNode node, JsonArray headers) => new ResourceIds
    {
        ResourceId = node.GetValueFor<byte[]>("ResourceId", headers),
        Exists = node.GetValueFor<bool>("Exists", headers)
    };
}