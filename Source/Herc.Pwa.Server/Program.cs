namespace Herc.Pwa.Server
{
  using System;
  using Herc.Pwa.Server.Data;
  using Microsoft.AspNetCore;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;

  public class Program
  {
    public static void Main(string[] args)
    {
      IWebHost host = BuildWebHost(args);

      using (IServiceScope scope = host.Services.CreateScope())
      {
        System.IServiceProvider services = scope.ServiceProvider;
        try
        {
          HercPwaDbContext hercPwaDbContext = services.GetRequiredService<HercPwaDbContext>();
          DbInitializer.Initialize(hercPwaDbContext);
        }
        catch (Exception ex)
        {
          ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred creating the DB.");
        }
      }
      host.Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .Build();
  }
}
