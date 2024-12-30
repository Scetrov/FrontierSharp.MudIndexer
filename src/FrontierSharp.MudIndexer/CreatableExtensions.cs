using System.Text.Json;
using System.Text.Json.Nodes;

namespace FrontierSharp.MudIndexer;

public static class CreatableExtensions {
    private static int GetIndexOfString(this JsonArray array, string value) =>
        array.Select((node, index) => new { node, index })
            .FirstOrDefault(x =>
                string.Equals(x.node?.GetValue<string>(), value, StringComparison.InvariantCultureIgnoreCase))?.index ??
        throw new InvalidOperationException($"Unable to find the index of `{value}` in the headers");

    public static int GetHeaderIndex(this JsonArray array, string header) =>
        array.GetIndexOfString(header);
    
    public static T GetValueFor<T>(this JsonNode node, string property, JsonArray headers) {
        var valueNode = node[headers.GetHeaderIndex(property)];

        if (valueNode == null) {
            throw new InvalidOperationException(MissingData);
        }
        
        if (typeof(T) == typeof(byte[])) {
            return (T)(object)valueNode.GetValue<string>().HexStringToByteArray();
        }
        if (typeof(T) == typeof(IEnumerable<string>)) {
            return (T)valueNode.AsArray().Select(x => x!.GetValue<string>());
        }
        if (typeof(T) != typeof(string) && valueNode.GetValueKind() == JsonValueKind.String) {
            return (T)Convert.ChangeType(valueNode.GetValue<string>(), typeof(T));
        }
        return valueNode.GetValue<T>();
    }

    private static byte[] HexStringToByteArray(this string hexString) {
        var length = hexString.Length;
        var byteArray = new byte[length / 2];
        var prefixed = hexString.StartsWith("0x");
        for (var i = prefixed ? 2 : 0; i < length; i += 2) {
            byteArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
        }
        return byteArray;
    }

    private static readonly string MissingData = "Missing Data";
}