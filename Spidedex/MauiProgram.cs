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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IDataAccessService, DataAccessService>();

		builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();

		builder.Services.AddSingleton<RegisterPage>();
		builder.Services.AddSingleton<RegisterPageViewModel>();

		builder.Services.AddSingleton<MySpidersPage>();
		builder.Services.AddSingleton<MySpidersPageViewModel>();

		builder.Services.AddSingleton<LoadingPage>();
		builder.Services.AddSingleton<LoadingPageViewModel>();

		builder.Services.AddTransient<AddUpdateMySpidersPage>();
		builder.Services.AddTransient<AddUpdateMySpidersPageViewModel>();

        return builder.Build();
	}
}
