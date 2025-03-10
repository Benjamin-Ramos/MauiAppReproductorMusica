using MauiAppReproductor.Models;

namespace MauiAppReproductor.ApiService
{
    public interface IApiService
    {
        public Task<Song> GetSongAsync(int id);
        public Task<List<Song>> GetAllSongsAsync();
        public Task<List<Album>> GetAllAlbumsAsync();
        public Task<List<Song>> GetSongsByAlbumIdAsync(int id);
    }
}
