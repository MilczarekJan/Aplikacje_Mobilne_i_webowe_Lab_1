using Microsoft.Extensions.Logging;
using P10MAUI.Models;
using P10MAUI.Data;
using Syncfusion.Blazor;

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

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

			builder.Services.AddSingleton<WeatherForecastService>();
			builder.Services.AddSingleton<Shoe>();
			builder.Services.AddSyncfusionBlazor();
			return builder.Build();
		}
	}
}