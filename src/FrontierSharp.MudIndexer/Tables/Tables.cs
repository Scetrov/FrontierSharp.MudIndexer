namespace FrontierSharp.MudIndexer.Tables;
public class Tables {
    public required byte[] TableId { get; set; }
    public required byte[] FieldLayout { get; set; }
    public required byte[] KeySchema { get; set; }
    public required byte[] ValueSchema { get; set; }
    public required byte[] AbiEncodedKeyNames { get; set; }
    public required byte[] AbiEncodedFieldNames { get; set; }
}