namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class RoleFactory
{
    public static string DefaultQuery => "SELECT \"role\", \"value\" FROM eveworld__Role;";

    public Role FromJsonNode(JsonNode node, JsonArray headers) => new Role
    {
        RoleName = node.GetValueFor<byte[]>("Role", headers),
        Value = node.GetValueFor<string>("Value", headers)
    };
}