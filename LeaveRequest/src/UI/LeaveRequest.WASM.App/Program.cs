using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LeaveRequest.WASM.App;
using LeaveRequest.WASM.App.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(cfg =>
{
    cfg.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IJobCategoryDataService,JobCategoryDataService>(cfg =>
{
    cfg.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<ICountryDataService,CountryDataService>(cfg =>
{
    cfg.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
await builder.Build().RunAsync();
