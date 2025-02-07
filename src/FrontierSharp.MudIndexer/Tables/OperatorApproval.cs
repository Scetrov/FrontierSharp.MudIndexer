namespace FrontierSharp.MudIndexer.Tables;
public class OperatorApproval {
    public required string Owner { get; set; }
    public required string Operator { get; set; }
    public required bool Approved { get; set; }
}