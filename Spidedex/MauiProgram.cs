using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Spidedex.Services;
using Spidedex.View;
using Spidedex.ViewModel;

namespace Spidedex;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("Caveat-Regular.ttf", "Caveat-Regular");
				fonts.AddFont("Caveat-SemiBold.ttf", "CaveatSemiBold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IDataAccessService, DataAccessService>();

		builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();

		builder.Services.AddSingleton<RegisterPage>();
		builder.Services.AddSingleton<RegisterPageViewModel>();

        builder.Services.AddSingleton<ResetPasswordPage>();
        builder.Services.AddSingleton<ResetPasswordPageViewModel>();

        builder.Services.AddSingleton<MySpidersPage>();
		builder.Services.AddSingleton<MySpidersPageViewModel>();

		builder.Services.AddSingleton<LoadingPage>();
		builder.Services.AddSingleton<LoadingPageViewModel>();

        builder.Services.AddSingleton<SpiderFactSheetsPage>();
        builder.Services.AddSingleton<SpiderFactSheetsPageViewModel>();

        builder.Services.AddTransient<AddUpdateMySpidersPage>();
		builder.Services.AddTransient<AddUpdateMySpidersPageViewModel>();

        return builder.Build();
	}
}
