using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using P06Shop.Shared.Services.ShoeServices;
using P06Shop.Shared.Services.AuthService;
using P10MAUI.Models;
using P10MAUI;
using P10MAUI.Services.CustomAuthStateProvider;
using Syncfusion.Blazor;
using P06Shop.Shared.Configuration;

namespace P10MAUI
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services.AddMauiBlazorWebView();

            var uriBuilder = new UriBuilder("http://localhost:5093") //appSettingsSection.BaseAPIUrl
            {
                //Path = appSettingsSection.BaseAPIUrl
            };

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AppSettings>();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddSingleton<WeatherForecastService>();
			builder.Services.AddTransient<GetShoesService>();
			builder.Services.AddTransient<AddShoeService>();
			builder.Services.AddTransient<DeleteShoeService>();
			builder.Services.AddTransient<UpdateShoeService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder.Uri);                                                                                                           
            builder.Services.AddSyncfusionBlazor();
            return builder.Build();
		}
	}
}