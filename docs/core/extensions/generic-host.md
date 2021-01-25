---
title: .NET 汎用ホスト
author: IEvangelist
description: アプリケーションの起動と生存期間の管理を行う .NET 汎用ホストについて説明します。
ms.author: dapine
ms.date: 12/18/2020
---

# .NET 汎用ホスト

ワーカーサービステンプレートは .NET 汎用ホスト(<xref:Microsoft.Extensions.Hosting.HostBuilder>)を作成します。汎用ホストはコンソールアプリの様な .NET アプリケーションと共に使用します。

**ホスト**は下記の様なリソースをカプセル化するオブジェクトです。

- 依存性注入 (DI)
- ログ出力
- 構成設定
- `IHostedService` 実装

ホストは開始時にサービスコンテナ上に登録された <xref:Microsoft.Extensions.Hosting.IHostedService> 実装の全ての <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A?displayProperty=nameWithType> を呼び出します。ワーカーサービスアプリでは、<xref:Microsoft.Extensions.Hosting.BackgroundService> から派生した `IHostedService` 実装のインスタンスは <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync%2A?displayProperty=nameWithType> も呼び出されます。

アプリの全ての相互依存リソースを一つのオブジェクトに含める主な理由は生存期間の管理を行う為です。開始から終了まで制御します。これは NuGet パッケージ [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) で実現します。

## ホストを設定する

ホストの構成と実行は通常、`Program` クラスの `Main` 関数で行います。

- <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder> を呼び出し、ビルダーを生成し構成します。
- <xref:Microsoft.Extensions.Hosting.IHostBuilder.Build> を呼び出し、<xref:Microsoft.Extensions.Hosting.IHost> インスタンスを作成します。
- ホストオブジェクトに対し、<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> または <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync%2A> を呼び出します。

.NET ワーカーサービステンプレートは下記の様にして、汎用ホストを作成するコードを生成します。

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            });
}
```

## 既定のビルダ設定

<xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> メソッドは下記の様にして構成します。

- コンテンツルートを <xref:System.IO.Directory.GetCurrentDirectory> に設定します。
- [ホストの構成設定](#host-configuration) を読み込みます。
  - Environment variables prefixed with `DOTNET_`.
  - `DOTNET_` の接頭辞を持つ環境変数を読み込みます。
  - コマンドライン引数を読み込みます。
- アプリケーションの構成設定を読み込みます。
  - *appsettings.json* から設定を読み込みます。
  - *appsettings.{Environment}.json*　から設定を読み込みます。
  - `Development` 環境で実行される時、シークレットマネージャを読み込みます。
  - 環境変数を読み込みます。
  - コマンドライン引数を読み込みます。
- 下記のログ出力プロバイダを追加します。
  - Console
  - Debug
  - EventSource
  - EventLog (Windows で実行される場合のみ)
- `Development` 環境で実行される場合、スコープの検証と [依存性の検証](xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild) を有効にします。

`ConfigureServices` メソッドは <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection?displayProperty=nameWithType> インスタンスにサービスを追加できる様にします。その後、サービスは依存性注入により利用できるようになります。

## フレームワークにより提供されるサービス

下記のサービスは自動的に登録されます。

- [IHostApplicationLifetime](#ihostapplicationlifetime)
- [IHostLifetime](#ihostlifetime)
- [IHostEnvironment](#ihostenvironment)

## IHostApplicationLifetime

開始後と終了処理を実行する為に <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> サービスを注入します。三つのプロパティは開始時と終了時に呼び出されるイベントハンドラを登録する為のキャンセルトークンです。このインターフェースは <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication> も含みます。

下記は `IHostApplicationLifetime` にイベントを登録する `IHostedService` の実装例です。

:::code language="csharp" source="snippets/configuration/app-lifetime/ExampleHostedService.cs" highlight="18-20":::

The Worker Service template could be modified to add the `ExampleHostedService` implementation:

ワーカーサービステンプレートを編集して `ExampleHostedService` を追加します。

:::code language="csharp" source="snippets/configuration/app-lifetime/Program.cs" range="1-16,36" highlight="15":::

アプリケーションは下記のサンプル出力を書き出します。

:::code language="csharp" source="snippets/configuration/app-lifetime/Program.cs" range="17-35":::

## IHostLifetime

<xref:Microsoft.Extensions.Hosting.IHostLifetime> はホストをいつ開始し、いつ終了するかを制御します。最後に登録したものが利用されます。

`Microsoft.Extensions.Hosting.Internal.ConsoleLifetime` は既定の `IHostLifetime` の実装です。

- <kbd>Ctrl</kbd>+<kbd>C</kbd>、[SIGINT](https://en.wikipedia.org/wiki/Signal_(IPC)#SIGINT)、または [SIGTERM](https://en.wikipedia.org/wiki/Signal_(IPC)#SIGTERM) の入力を受け取り、<xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication%2A> を呼び出し終了プロセスを開始します。
- `RunAsync` と `WaitForShutdownAsync` の様な拡張のブロックを解除します。

## IHostEnvironment

<xref:Microsoft.Extensions.Hosting.IHostEnvironment> サービスをクラスに注入し下記の設定情報を取得します。

- <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ApplicationName?displayProperty=nameWithType> (アプリケーション名)
- <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootFileProvider?displayProperty=nameWithType> (コンテンツルートのファイル)
- <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath?displayProperty=nameWithType> (コンテンツルートのパス)
- <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName?displayProperty=nameWithType> (環境の名前)

## ホストの構成設定

ホストの構成設定は [IHostEnvironment](#ihostenvironment) 実装のプロパティを構成する為に利用されます。

ホストの構成設定は　<xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> メソッド内の [HostBuilderContext.Configuration](xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration) で利用可能です。`ConfigureAppConfiguration` メソッドを呼び出す時、`HostBuilderContext` と `IConfigurationBuilder` が `configureDelegate` に渡されます。`configureDelegate` は `Action<HostBuilderContext, IConfigurationBuilder>` として定義されています。ホストビルダのコンテキストは `IConfiguration` 型の `.Configuration` プロパティを公開します。これはホストから構築される構成設定を表します。`IConfigurationBuilder` はアプリケーションの構成を行うビルダオブジェクトです。

> [!TIP]
> `ConfigureAppConfiguration` を呼び出した後の `HostBuilderContext.Configuration` は [アプリケーションの構成設定](#app-configuration) に置き換わります。

ホストに構成設定を追加するには、`IHostBuilder` の <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureHostConfiguration%2A> を呼び出します。`ConfigureHostConfiguration` を複数回呼び出して設定を追加する事もできます。ホストは最後に設定された値を利用します。

下記の例ではホストの構成設定を作成しています。

:::code language="csharp" source="snippets/configuration/console-host/Program.cs" highlight="19-25":::

## アプリケーションの構成設定

`ConfigureAppConfiguration` can be called multiple times with additive results. The app uses whichever option sets a value last on a given key.

アプリケーションの構成設定は `IHostBuilder` の <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> を呼び出す事により作成されます。`ConfigureAppConfiguration` を複数回呼び出して設定を追加する事もできます。アプリケーションは最後に設定された値を利用します。

`ConfigureAppConfiguration` によって作成された構成設定は、その後の操作及びDIのサービスとして [HostBuilderContext.Configuration](xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A) から利用可能です。ホストの構成設定もアプリケーションの構成設定に追加されます。

詳細は [.NET での構成設定](configuration.md) をご覧ください。

## 関連項目

- [.NET での構成設定](configuration.md)
- [ASP.NET Core Web Host](/aspnet/core/fundamentals/host/web-host)
- 汎用ホストの不具合は [github.com/dotnet/extensions](https://github.com/dotnet/extensions/issues) リポジトリでお知らせください。
