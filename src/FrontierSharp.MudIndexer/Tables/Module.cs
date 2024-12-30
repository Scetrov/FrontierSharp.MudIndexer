namespace FrontierSharp.MudIndexer.Tables;
public class Module {
    public required string ModuleId { get; set; }
    public required byte[] SystemId { get; set; }
    public required byte[] ModuleName { get; set; }
    public required bool DoesExists { get; set; }
}