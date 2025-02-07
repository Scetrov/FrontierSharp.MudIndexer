namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class TablesFactory : IFactory<Tables>
{
    public static string DefaultQuery => "SELECT \"tableId\", \"fieldLayout\", \"keySchema\", \"valueSchema\", \"abiEncodedKeyNames\", \"abiEncodedFieldNames\" FROM store__Tables;";

    public Tables FromJsonNode(JsonNode node, JsonArray headers) => new Tables
    {
        TableId = node.GetValueFor<byte[]>("TableId", headers),
        FieldLayout = node.GetValueFor<byte[]>("FieldLayout", headers),
        KeySchema = node.GetValueFor<byte[]>("KeySchema", headers),
        ValueSchema = node.GetValueFor<byte[]>("ValueSchema", headers),
        AbiEncodedKeyNames = node.GetValueFor<byte[]>("AbiEncodedKeyNames", headers),
        AbiEncodedFieldNames = node.GetValueFor<byte[]>("AbiEncodedFieldNames", headers)
    };
}