using Microsoft.Extensions.Logging;
using MauiApp2.Services;
using MauiApp2.ViewModel;

namespace MauiApp2;

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
				fonts.AddFont("Grenze-Regular.ttf", "Grenze");
			});

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<GalleryService>();
        builder.Services.AddTransient<GalleryViewModel>();

        builder.Services.AddScoped<Gallery>();
        builder.Services.AddScoped<GalleryViewModel, GalleryViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
