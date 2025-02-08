namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class OperatorApprovalFactory : IFactory<OperatorApproval>
{
    public static string DefaultQuery => "SELECT \"owner\", \"operator\", \"approved\" FROM erc721deploybl__OperatorApproval;";

    public OperatorApproval FromJsonNode(JsonNode node, JsonArray headers) => new OperatorApproval
    {
        Owner = node.GetValueFor<string>("Owner", headers),
        Operator = node.GetValueFor<string>("Operator", headers),
        Approved = node.GetValueFor<bool>("Approved", headers)
    };
}