using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using MudBlazor;
using MudBlazor.Services;
using SMS.Service.HTTP;
using SMS.Service.Manager;
using System.IdentityModel.Tokens.Jwt;
using Configuration = SMS.Models.Application.Configuration;

namespace SMS.Dependency
{
    public static class InfrastructureService
    {
        public static void AddInfrastructureService(this IServiceCollection services, WebAssemblyHostBuilder builder)
        {
            var configuration = builder.Configuration;

            var environment = builder.HostEnvironment;

            Console.WriteLine($"Environment: {builder.HostEnvironment.Environment}.");
            Console.WriteLine($"Base Address: {builder.HostEnvironment.BaseAddress}.");

            configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.Environment}.json", optional: true, reloadOnChange: true);

            var applicationConfiguration = configuration.GetSection("Configuration").Get<Configuration>()
                ?? throw new KeyNotFoundException("The application configuration could not be found, please try again.");

           /* var syncfusionConfiguration = configuration.GetSection("SyncfusionSettings").Get<SyncfusionSettings>()
                                          ?? throw new KeyNotFoundException("The syncfusion configuration could not be found, please try again.");*/

           // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusionConfiguration.LicenseKey);

            services.AddDependencyServices();

            services.AddSingleton<JwtSecurityTokenHandler>();

            services.AddScoped<IdentityAuthenticationStateManager>();

            services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<IdentityAuthenticationStateManager>());

            services.AddScoped(_ => new ApiHttpClient(new HttpClient(), applicationConfiguration.ApiUrl));

            services.AddScoped(_ => new LocalHttpClient(new HttpClient(), builder.HostEnvironment.BaseAddress));

            services.AddLocalization();

            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
            });

            services
                .AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

           // services.AddSyncfusionBlazor();

            services.AddBlazoredLocalStorage();

            services.AddAuthorizationCore();

            services.Configure<StaticFileOptions>(options =>
            {
                options.ServeUnknownFileTypes = true;
                var provider = new FileExtensionContentTypeProvider();
                provider.Mappings.Add(".js", "application/javascript");
                options.ContentTypeProvider = provider;
            });
        }
    }
}
