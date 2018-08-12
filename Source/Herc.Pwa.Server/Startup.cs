namespace Herc.Pwa.Server
{
  using System.Linq;
  using System.Net.Mime;
  using AutoMapper;
  using Herc.Pwa.Server.Data;
  using MediatR;
  using Microsoft.AspNetCore.Blazor.Server;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.ResponseCompression;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAutoMapper();

      string connectionString = Configuration.GetConnectionString(nameof(HercPwaDbContext));
      services.AddDbContext<HercPwaDbContext>(options =>
        options.UseSqlServer(connectionString)
      );

      services.AddMvc();

      services.AddResponseCompression(options =>
      {
        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
              {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
          });
      });
      services.AddMediatR();
      services.Scan(scan => scan
        .FromAssemblyOf<Startup>()
        .AddClasses()
        .AsSelf()
        .WithScopedLifetime());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseResponseCompression();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc(routes =>
      {
        routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
      });

      app.UseBlazor<Client.Program>();
    }
  }
}
