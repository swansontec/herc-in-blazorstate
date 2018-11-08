namespace Herc.Pwa.Server
{
  using System.Linq;
  using System.Net.Mime;
  using System.Reflection;
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
  using Newtonsoft.Json.Serialization;

  public class Startup
  {
    public Startup(IConfiguration aConfiguration)
    {
      Configuration = aConfiguration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder aApplicationBuilder, IHostingEnvironment aHostingEnvironment)
    {
      aApplicationBuilder.UseStaticFiles();
      aApplicationBuilder.UseResponseCompression();

      if (aHostingEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
      }

      aApplicationBuilder.UseMvc(aRouteBuilder =>
      {
        aRouteBuilder.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
      });

      aApplicationBuilder.UseBlazor<Client.Program>();
    }

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddCors(aCorsOptions =>
      {
        aCorsOptions.AddPolicy("any",
            aCorsPolicyBuilder => aCorsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
      });

      var assemblies = new Assembly[] { typeof(Startup).Assembly };
      aServiceCollection.AddAutoMapper(assemblies);

      string connectionString = Configuration.GetConnectionString(nameof(HercPwaDbContext));
      aServiceCollection.AddDbContext<HercPwaDbContext>(options =>
        options.UseSqlServer(connectionString)
      );

      aServiceCollection.AddMvc()
        .AddJsonOptions(aMvcJsonOptions =>
        {
          aMvcJsonOptions.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });

      aServiceCollection.AddResponseCompression(aResponseCompressionOptions =>
      {
        aResponseCompressionOptions.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[]
          {
            MediaTypeNames.Application.Octet,
            WasmMediaTypeNames.Application.Wasm,
          });
      });
      aServiceCollection.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
      aServiceCollection.Scan(aTypeSourceSelector => aTypeSourceSelector
        .FromAssemblyOf<Startup>()
        .AddClasses()
        .AsSelf()
        .WithScopedLifetime());
    }
  }
}