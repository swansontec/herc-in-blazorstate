namespace Herc.Pwa.Client
{
  using Blazor.Extensions.Logging;
  using BlazorState;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Client.Shared;
  using Microsoft.AspNetCore.Blazor.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;

  public class Startup
  {
    public void Configure(IBlazorApplicationBuilder aBlazorApplicationBuilder) =>
      aBlazorApplicationBuilder.AddComponent<App>("app");

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddSingleton<ColorPalette>();
      aServiceCollection.AddSingleton<BalanceFormater>();
      aServiceCollection.AddLogging(aLoggingBuilder => aLoggingBuilder
          .AddBrowserConsole()
          .SetMinimumLevel(LogLevel.Trace)
      );
      aServiceCollection.AddBlazorState();
    }
  }
}