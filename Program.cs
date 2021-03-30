using System;
using System.Net.Http;
using System.Threading.Tasks;
using dotnetnotts_web.HttpClients;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetnotts
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<MeetupApiHttpClient>(config =>
            {
                config.BaseAddress = new Uri("https://dotnetnotts-api.azurewebsites.net");
            });

            await builder.Build().RunAsync();
        }
    }
}
