namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class SmartAssemblyFactory : IFactory<SmartAssembly>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"smartAssemblyType\" FROM eveworld__SmartAssemblyTab;";

    public SmartAssembly FromJsonNode(JsonNode node, JsonArray headers) => new SmartAssembly
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        SmartAssemblyType = node.GetValueFor<byte>("SmartAssemblyType", headers)
    };
}