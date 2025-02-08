using System.Net.Http.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Caching.Hybrid;

namespace FrontierSharp.MudIndexer;

public class MudClient(
    IMudWorld world,
    IHttpClientFactory clientFactory,
    HybridCache cache,
    string queryEndpoint = "https://indexer.mud.garnetchain.com/q") : IMudClient {
    public async Task<IEnumerable<T>> Query<T, TFactory>(string mudQuery, CancellationToken cancellationToken = default)
        where TFactory : IFactory<T>, new() {
        QueryObj[] payload = [new() { address = world.Address, query = mudQuery }];
        return await cache.GetOrCreateAsync($"{world.Address}:{mudQuery}", async entry => {
            var client = clientFactory.CreateClient("MudIndexer");
            var response = await client.PostAsync(queryEndpoint, JsonContent.Create(payload), cancellationToken);

            if (!response.IsSuccessStatusCode) {
                var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new InvalidOperationException(
                    $"The query `{mudQuery}` failed with status code {response.StatusCode} and message: \n`{errorContent}`");
            }

            var content = await response.Content.ReadAsStreamAsync(cancellationToken);
            var node = await JsonNode.ParseAsync(content, cancellationToken: cancellationToken);

            if (node == null) {
                var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new InvalidOperationException(
                    $"Unable to parse the response, unexpected payload: \n`{errorContent}`");
            }

            var data = node["result"]?.AsArray()
                .Where(x => x is JsonArray)
                .SelectMany(x => x!.AsArray())
                .ToArray();
            var headers = data?.First()?.AsArray();

            if (headers is null)
                throw new InvalidOperationException(
                    "Unable to parse the headers, unexpected payload.");

            var creatable = new TFactory();
            return data?.Skip(1).Where(x => x is not null).Select(x => creatable.FromJsonNode(x!, headers))!;
        }, cancellationToken: cancellationToken);
    }

    private struct QueryObj {
        // ReSharper disable InconsistentNaming
        public string address { get; set; }

        public string query { get; set; }
        // ReSharper restore InconsistentNaming
    }
}