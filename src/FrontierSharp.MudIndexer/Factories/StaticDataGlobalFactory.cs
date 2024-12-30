namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class StaticDataGlobalFactory
{
    public static string DefaultQuery => "SELECT \"systemId\", \"name\", \"symbol\", \"baseURI\" FROM eveworld__StaticDataGlobal;";

    public StaticDataGlobal FromJsonNode(JsonNode node, JsonArray headers) => new StaticDataGlobal
    {
        SystemId = node.GetValueFor<byte[]>("SystemId", headers),
        Name = node.GetValueFor<string>("Name", headers),
        Symbol = node.GetValueFor<string>("Symbol", headers),
        BaseURI = node.GetValueFor<string>("BaseURI", headers)
    };
}