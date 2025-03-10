using System.Text.Json.Serialization;

namespace MauiAppReproductor.Models
{
    public class Song
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }

        [JsonPropertyName("track_num")]
        public int TrackNum { get; set; }
        public string File { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int Id { get; set; }

        public Album Album { get; set; }
        public Genre Genre { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
