namespace FrontierSharp.MudIndexer;

public interface IMudClient {
    Task<IEnumerable<T>> Query<T>(string mudQuery, CancellationToken cancellationToken) where T : IFactory<T>, new();
}