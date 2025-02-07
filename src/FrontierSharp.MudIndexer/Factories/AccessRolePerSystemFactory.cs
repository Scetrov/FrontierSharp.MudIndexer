namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class AccessRolePerSystemFactory : IFactory<AccessRolePerSystem>
{
    public static string DefaultQuery => "SELECT \"systemId\", \"roleId\", \"accounts\" FROM eveworld__AccessRolePerSys;";

    public AccessRolePerSystem FromJsonNode(JsonNode node, JsonArray headers) => new AccessRolePerSystem
    {
        SystemId = node.GetValueFor<byte[]>("SystemId", headers),
        RoleId = node.GetValueFor<byte[]>("RoleId", headers),
        Accounts = node.GetValueFor<IEnumerable<string>>("Accounts", headers)
    };
}