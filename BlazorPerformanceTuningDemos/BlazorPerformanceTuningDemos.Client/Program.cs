using BlazorPerformanceTuningDemos.Client.DataCaching;
using BlazorPerformanceTuningDemos.Client.DemoData;
using Havit.Blazor.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHxServices();
builder.Services.AddHxMessenger();
builder.Services.AddHxMessageBoxHost();

builder.Services.AddSingleton<IDemoDataService, DemoDataService>();
builder.Services.AddSingleton<IEmployeesDataStore, EmployeesDataStore>();

await builder.Build().RunAsync();
