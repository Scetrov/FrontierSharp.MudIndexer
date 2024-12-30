namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class ClassConfigFactory
{
    public static string DefaultQuery => "SELECT \"systemId\", \"classId\" FROM eveworld__ClassConfig;";

    public ClassConfig FromJsonNode(JsonNode node, JsonArray headers) => new ClassConfig
    {
        SystemId = node.GetValueFor<byte[]>("SystemId", headers),
        ClassId = node.GetValueFor<string>("ClassId", headers)
    };
}