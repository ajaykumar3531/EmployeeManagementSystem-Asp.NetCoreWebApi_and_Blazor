using BlazorUI;
using BlazorUI.Services.DepartmentService;
using BlazorUI.Services.DepartmentServices;
using BlazorUI.Services.EmployeeServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7209/") });
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<IDepartmentService,DepartmentService>();    
await builder.Build().RunAsync();
