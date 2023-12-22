using ListaTareas.Client;
using ListaTareas.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//injection
builder.Services.AddScoped<IPeticionHTTP, PeticionHTTP>();
builder.Services.AddScoped<PeticionHTTP>();

await builder.Build().RunAsync();
