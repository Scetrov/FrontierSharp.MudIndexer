namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class AccessRoleFactory
{
    public static string DefaultQuery => "SELECT \"roleId\", \"accounts\" FROM eveworld__AccessRole;";

    public AccessRole FromJsonNode(JsonNode node, JsonArray headers) => new AccessRole
    {
        RoleId = node.GetValueFor<byte[]>("RoleId", headers),
        Accounts = node.GetValueFor<IEnumerable<string>>("Accounts", headers)
    };
}