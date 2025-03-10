using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppReproductor.ApiService;
using MauiAppReproductor.Models;
using MauiAppReproductor.Pages;
using System.Collections.ObjectModel;

namespace MauiAppReproductor.PageModels;

public partial class AlbumsPageModel : ObservableObject
{
    private readonly IApiService _apiService;

    [ObservableProperty]
    private ObservableCollection<Album> _albums;

    public AlbumsPageModel(IApiService apiService)
    {
        _apiService = apiService;
        LoadAlbums();
    }

    [RelayCommand]
    private async Task ShowAlbumDetail(Album album)
    {
        if (album == null) return;

        var viewModel = new AlbumDetailPageModel(_apiService);
        await Shell.Current.Navigation.PushAsync(new AlbumDetailPage(viewModel, album));
    }

    private async void LoadAlbums()
    {
        try
        {
            var albums = await _apiService.GetAllAlbumsAsync();
            Albums = new ObservableCollection<Album>(albums);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}