namespace MauiAppReproductor.Models
{
    public class Album
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Picture { get; set; }
        public int ArtistId { get; set; }
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public List<Song> Songs { get; set; } = new();
    }
}
