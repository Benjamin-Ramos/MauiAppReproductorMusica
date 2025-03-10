using CommunityToolkit.Maui;
using MauiAppReproductor.ApiService;
using MauiAppReproductor.PageModels;
using MauiAppReproductor.Pages;

namespace MauiAppReproductor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddSingleton<InfoPageModel>();
        builder.Services.AddSingleton<HomePageModel>();
        builder.Services.AddSingleton<AlbumsPageModel>();
        builder.Services.AddSingleton<AlbumDetailPageModel>();

        builder.Services.AddSingleton<InfoPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<AlbumsPage>();
        builder.Services.AddSingleton<AlbumDetailPage>();

        builder.Services.AddSingleton<IApiService, MusicApiService>();

        return builder.Build();
    }
}