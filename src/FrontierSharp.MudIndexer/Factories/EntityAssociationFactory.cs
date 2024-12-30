namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EntityAssociationFactory
{
    public static string DefaultQuery => "SELECT \"entityId\", \"moduleIds\", \"hookIds\" FROM eveworld__EntityAssociatio;";

    public EntityAssociation FromJsonNode(JsonNode node, JsonArray headers) => new EntityAssociation
    {
        EntityId = node.GetValueFor<string>("EntityId", headers),
        ModuleIds = node.GetValueFor<IEnumerable<string>>("ModuleIds", headers),
        HookIds = node.GetValueFor<IEnumerable<string>>("HookIds", headers)
    };
}