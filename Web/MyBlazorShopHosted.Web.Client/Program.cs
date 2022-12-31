using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorShopHosted.Web.Client;
using MyBlazorShopHosted.Web.Client.StateManagement;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(serviceProvider => {
    var http = new HttpClient()
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    };
    http.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
    {
        NoCache = true
    };
    return http;
});
builder.Services.AddSingleton<IShoppingCartStateContainer, ShoppingCartStateContainer>();

await builder.Build().RunAsync();
