namespace NexusGames.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Price { get; set; }


    }
}
