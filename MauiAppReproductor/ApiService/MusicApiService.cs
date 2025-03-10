using MauiAppReproductor.Models;
using System.Diagnostics;
using System.Net.Http.Json;

namespace MauiAppReproductor.ApiService
{
    public class MusicApiService : IApiService
    {
        private readonly HttpClient _client;

        public MusicApiService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
        }

        public async Task<List<Song>> GetSongsByAlbumIdAsync(int albumId)
        {
            try
            {
                var response = await _client.GetAsync($"albums/{albumId}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                }

                var album = await response.Content.ReadFromJsonAsync<Album>();

                foreach (var song in album.Songs)
                {
                    if (!string.IsNullOrEmpty(song?.File) && !song.File.StartsWith("http"))
                    {
                        song.File = "http://localhost:8080" + song.File;
                    }
                }
                return album.Songs;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión con la API.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error desconocido al obtener las canciones del álbum.", ex);
            }
        }
        public async Task<List<Album>> GetAllAlbumsAsync()
        {
            try
            {
                var response = await _client.GetAsync("http://localhost:8080/albums");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error al obtener los álbumes: {response.StatusCode}");

                var albums = await response.Content.ReadFromJsonAsync<List<Album>>();

                if (albums == null)
                    throw new Exception("No se recibieron álbumes.");

                foreach (var album in albums)
                {
                    if (!string.IsNullOrEmpty(album?.Picture) && !album.Picture.StartsWith("http"))
                    {
                        album.Picture = "http://localhost:8080" + album.Picture;
                    }
                }

                return albums;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión con la API.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error desconocido al obtener los álbumes.", ex);
            }
        }

        public async Task<List<Song>> GetAllSongsAsync()
        {
            try
            {
                var response = await _client.GetAsync("http://localhost:8080/songs");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error al obtener las canciones: {response.StatusCode}");

                var songs = await response.Content.ReadFromJsonAsync<List<Song>>();

                if (songs == null)
                    throw new Exception("No se recibieron canciones.");

                foreach (var song in songs)
                {
                    if (!string.IsNullOrEmpty(song?.Album?.Picture) && !song.Album.Picture.StartsWith("http"))
                    {
                        song.Album.Picture = "http://localhost:8080" + song.Album.Picture;
                    }

                    if (!string.IsNullOrEmpty(song?.File) && !song.File.StartsWith("http"))
                    {
                        song.File = "http://localhost:8080" + song.File;
                    }
                }

                return songs;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión con la API.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error desconocido al obtener las canciones.", ex);
            }
        }

        public async Task<Song> GetSongAsync(int songId)
        {
            try
            {
                var response = await _client.GetAsync($"songs/{songId}");

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error al obtener la canción: {response.StatusCode}");

                var song = await response.Content.ReadFromJsonAsync<Song>();

                if (song == null)
                    throw new Exception("La canción recibida es nula.");

                return song;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de conexión con la API.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error desconocido al obtener la canción.", ex);
            }
        }
    }
}