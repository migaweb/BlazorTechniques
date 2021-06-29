using BlazorTechniques.Client.Components.BusyOverlay;
using BlazorTechniques.Client.Stores.ArticleStore;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTechniques.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

      builder.Services.AddScoped<ArticleStore>();
      builder.Services.AddScoped<BusyOverlayService>();

      await builder.Build().RunAsync();
    }
  }
}
