namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class AccessRolePerObjectFactory : IFactory<AccessRolePerObject>
{
    public static string DefaultQuery => "SELECT \"smartObjectId\", \"roleId\", \"accounts\" FROM eveworld__AccessRolePerObj;";

    public AccessRolePerObject FromJsonNode(JsonNode node, JsonArray headers) => new AccessRolePerObject
    {
        SmartObjectId = node.GetValueFor<string>("SmartObjectId", headers),
        RoleId = node.GetValueFor<byte[]>("RoleId", headers),
        Accounts = node.GetValueFor<IEnumerable<string>>("Accounts", headers)
    };
}