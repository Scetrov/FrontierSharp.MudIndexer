# FrontierSharp.MudIndexer

![GitHub last commit](https://img.shields.io/github/last-commit/scetrov/FrontierSharp.MudIndexer)
![NuGet Downloads](https://img.shields.io/nuget/dt/FrontierSharp.MudIndexer)
![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/scetrov/FrontierSharp.MudIndexer/dotnet.yml)
![GitHub issues](https://img.shields.io/github/issues/scetrov/FrontierSharp.MudIndexer)
![GitHub pull requests](https://img.shields.io/github/issues-pr/scetrov/FrontierSharp.MudIndexer)
![GitHub](https://img.shields.io/github/license/scetrov/FrontierSharp.MudIndexer)
![GitHub contributors](https://img.shields.io/github/contributors/scetrov/FrontierSharp.MudIndexer)

FrontierSharp.MudIndexer is a C# library designed to fetch EVE Frontier data from the Mud indexer. This project includes various utilities and tools to facilitate data handling and testing.

## Features

- Fetching data from the Mud indexer
- Code generation for additional tables
- Comprehensive unit tests

## Installation

To install FrontierSharp.MudIndexer, you can use the following NuGet command:

```sh
nuget install FrontierSharp.MudIndexer
```

## Usage

Here is an example of how to use `FrontierSharp.MudIndexer` in your project:

```csharp
using FrontierSharp.MudIndexer;
using FrontierSharp.MudIndexer.Factories;
using FrontierSharp.MudIndexer.Tables;
using Microsoft.Extensions.DependencyInjection;
using ZiggyCreatures.Caching.Fusion;

var services = new ServiceCollection();

services.AddHttpClient();
services.AddFusionCache().AsHybridCache();
services.AddScoped<IMudWorld, EveFrontierStillness>();
services.AddScoped<IMudClient, MudClient>();

var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IMudClient>();

var deployables = await client.Query<DeployableState, DeployableStateFactory>(DeployableStateFactory.DefaultQuery, new CancellationToken());

foreach (var d in deployables) {
  Console.WriteLine($"{d.SmartObjectId}: State = {d.CurrentState}, {d.AnchoredAt}");
}
```

## Building the Project

To build the project, use the following command:

```sh
dotnet build
```

## Running Tests

To run the tests, use the following command:

```sh
dotnet test
```

## Contributing

If you would like to contribute to this project, please follow these steps:

1. Fork the repository
2. Create a new branch (`git checkout -b feature-branch`)
3. Make your changes
4. Commit your changes (`git commit -am 'feat(x): Add new feature X'`)
5. Push to the branch (`git push origin feature-branch`)
6. Create a new Pull Request

> [!TIP]
> Use [conventional commits](https://www.conventionalcommits.org/en/v1.0.0/) to make your commits more readable and easier to understand.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

## Authors

- Scetrov

## Acknowledgments

- Special thanks to all contributors and supporters of this project.
