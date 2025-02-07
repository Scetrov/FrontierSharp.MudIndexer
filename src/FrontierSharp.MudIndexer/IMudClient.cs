namespace FrontierSharp.MudIndexer;

public interface IMudClient {
    Task<IEnumerable<T>> Query<T, TFactory>(string mudQuery, CancellationToken cancellationToken) where TFactory : IFactory<T>, new();
}