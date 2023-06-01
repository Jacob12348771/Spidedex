﻿using Microsoft.Extensions.Logging;
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
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<RegisterPage>();
		builder.Services.AddSingleton<RegisterPageViewModel>();
		builder.Services.AddSingleton<DashboardPage>();
		builder.Services.AddSingleton<DashboardPageViewModel>();
		builder.Services.AddSingleton<LoadingPage>();
		builder.Services.AddSingleton<LoadingPageViewModel>();

        return builder.Build();
	}
}
