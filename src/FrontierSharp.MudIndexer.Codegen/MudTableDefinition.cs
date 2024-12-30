public class MudTableDefinition {
    public required string Namespace { get; set; }
    public required string TableName { get; set; }
    public required IEnumerable<TableField> Fields { get; set; }
}