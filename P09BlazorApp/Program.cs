using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.Services.AuthService;
using P09BlazorApp;
using P09BlazorApp.Services.CustomAuthStateProvider;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilder = new UriBuilder("http://localhost:5093") //appSettingsSection.BaseAPIUrl
{
	//Path = appSettingsSection.BaseAPIUrl
};

//builder.Services.AddSingleton(appSettingsSection);
builder.Services.AddBlazoredLocalStorage();

// autorization
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AppSettings>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder.Uri); //uriBuilder.Uri
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
