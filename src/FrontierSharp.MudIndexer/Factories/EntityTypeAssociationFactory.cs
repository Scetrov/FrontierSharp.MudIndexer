namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class EntityTypeAssociationFactory
{
    public static string DefaultQuery => "SELECT \"entityType\", \"taggedEntityType\", \"isAllowed\" FROM eveworld__EntityTypeAssoci;";

    public EntityTypeAssociation FromJsonNode(JsonNode node, JsonArray headers) => new EntityTypeAssociation
    {
        EntityType = node.GetValueFor<byte>("EntityType", headers),
        TaggedEntityType = node.GetValueFor<byte>("TaggedEntityType", headers),
        IsAllowed = node.GetValueFor<bool>("IsAllowed", headers)
    };
}