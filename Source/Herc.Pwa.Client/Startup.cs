namespace Herc.Pwa.Client
{
  //using Blazor.Extensions.Logging;
  using BlazorState;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Client.Shared;
  using Microsoft.AspNetCore.Components.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;

  public class Startup
  {
    public void Configure(IComponentsApplicationBuilder aBlazorApplicationBuilder) =>
      aBlazorApplicationBuilder.AddComponent<App>("app");

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddSingleton<ColorPalette>();
      aServiceCollection.AddSingleton<AmountConverter>();
      //aServiceCollection.AddLogging(aLoggingBuilder => aLoggingBuilder
      //    .AddBrowserConsole()
      //    .SetMinimumLevel(LogLevel.Trace)
      //);
      aServiceCollection.AddBlazorState();
    }
  }
}