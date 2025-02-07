namespace FrontierSharp.MudIndexer.Factories;
using System.Text.Json.Nodes;
using FrontierSharp.MudIndexer.Tables;

public class KillMailTableFactory : IFactory<KillMailTable>
{
    public static string DefaultQuery => "SELECT \"killMailId\", \"killerCharacterId\", \"victimCharacterId\", \"lossType\", \"solarSystemId\", \"killTimestamp\" FROM eveworld__KillMailTable;";

    public KillMailTable FromJsonNode(JsonNode node, JsonArray headers) => new KillMailTable
    {
        KillMailId = node.GetValueFor<string>("KillMailId", headers),
        KillerCharacterId = node.GetValueFor<string>("KillerCharacterId", headers),
        VictimCharacterId = node.GetValueFor<string>("VictimCharacterId", headers),
        LossType = node.GetValueFor<byte>("LossType", headers),
        SolarSystemId = node.GetValueFor<string>("SolarSystemId", headers),
        KillTimestamp = node.GetValueFor<string>("KillTimestamp", headers)
    };
}