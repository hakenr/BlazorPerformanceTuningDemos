using BlazorPerformanceTuningDemos.Client.DemoData;
using Havit.Blazor.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHxServices();
builder.Services.AddHxMessenger();
builder.Services.AddHxMessageBoxHost();

builder.Services.AddSingleton<IDemoDataService, DemoDataService>();

await builder.Build().RunAsync();
