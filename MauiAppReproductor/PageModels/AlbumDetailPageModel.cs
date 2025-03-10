using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppReproductor.ApiService;
using MauiAppReproductor.Models;

namespace MauiAppReproductor.PageModels;

public partial class AlbumDetailPageModel : ObservableObject
{
    private readonly IApiService _apiService;

    [ObservableProperty]
    private Album _albumSelected;

    [ObservableProperty]
    private ObservableCollection<Song> _songs = new();

    public AlbumDetailPageModel(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async void Initialize(Album album)
    {
        AlbumSelected = album;
        await LoadSongsAsync();
    }

    public async Task LoadSongsAsync()
    {
        try
        {
            if (AlbumSelected == null) return;
            var albumSongs = await _apiService.GetSongsByAlbumIdAsync(AlbumSelected.Id);
            if (albumSongs == null || albumSongs.Count == 0)
            {
                return;
            }
            Songs = new ObservableCollection<Song>(albumSongs);
        }
        catch (Exception ex)
        {
        }
    }

}