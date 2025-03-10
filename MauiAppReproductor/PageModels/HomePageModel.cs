using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppReproductor.ApiService;
using MauiAppReproductor.Models;
using System.Collections.ObjectModel;

namespace MauiAppReproductor.PageModels;

public partial class HomePageModel : ObservableObject
{
    private readonly IApiService _apiService;

    [ObservableProperty]
    private ObservableCollection<Song> _songs;

    [ObservableProperty]
    private Song _currentSong;

    [ObservableProperty]
    private bool _isSongPlaying;

    public MediaElement MediaPlayer { get; set; }

    public HomePageModel(IApiService apiService)
    {
        _apiService = apiService;
        LoadSongs();
    }

    private async void LoadSongs()
    {
        try
        {
            var songs = await _apiService.GetAllSongsAsync();
            Songs = new ObservableCollection<Song>(songs);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    [RelayCommand]
    private async Task PlaySong(Song song)
    {
        try
        {
            if (song == null || MediaPlayer == null) return;

            CurrentSong = song;
            IsSongPlaying = true;

            if (MediaPlayer.CurrentState == MediaElementState.Playing)
                MediaPlayer.Stop();

            var baseUri = new Uri("http://localhost:8080/");
            var fullUri = new Uri(baseUri, song.File.TrimStart('/'));

            MediaPlayer.Source = fullUri;
            MediaPlayer.Play();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private void StopSong()
    {
        MediaPlayer?.Stop();
        IsSongPlaying = false;
        CurrentSong = null;
    }
}