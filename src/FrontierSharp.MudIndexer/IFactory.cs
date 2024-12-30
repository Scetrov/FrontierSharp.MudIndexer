using System.Text.Json.Nodes;

namespace FrontierSharp.MudIndexer;

public interface IFactory<out T> {
    public T FromJsonNode(JsonNode node, JsonArray headers);
}