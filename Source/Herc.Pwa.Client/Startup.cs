namespace Herc.Pwa.Client
{
  //using Blazor.Extensions.Logging;
  using BlazorState;
  using BlazorState.Services;
  using FluentValidation;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Client.Shared;
  using Microsoft.AspNetCore.Components.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Util;

  public class Startup
  {
    public void Configure(IComponentsApplicationBuilder aComponentsApplicationBuilder) =>
      aComponentsApplicationBuilder.AddComponent<App>("app");

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      if (new BlazorHostingLocation().IsClientSide)
      {
	      aServiceCollection.AddSingleton<ColorPalette>();
	      aServiceCollection.AddSingleton<AmountConverter>();
	      aServiceCollection.AddSingleton<AddressUtil>();
	      aServiceCollection.AddScoped(typeof(IValidator<SendAction>), typeof(SendValidator));
        // TODO add this back once Blazor.Extentions.Logging is updated to 0.8.0
        //aServiceCollection.AddLogging(aLoggingBuilder => aLoggingBuilder
        //    .AddBrowserConsole()
        //    .SetMinimumLevel(LogLevel.Trace));
      };
      aServiceCollection.AddBlazorState();
    }
  }
}