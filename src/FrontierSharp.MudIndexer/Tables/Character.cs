namespace FrontierSharp.MudIndexer.Tables;
public class Character {
    public required string CharacterId { get; set; }
    public required string CharacterAddress { get; set; }
    public required string CorpId { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
}