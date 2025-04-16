using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SMS;
using SMS.Dependency;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var rootComponent = builder.RootComponents;

rootComponent.Add<App>("#app");

rootComponent.Add<HeadOutlet>("head::after");

var services = builder.Services;

services.AddInfrastructureService(builder);

await builder.Build().RunAsync();
