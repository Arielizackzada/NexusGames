namespace NexusGames.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Category Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Price { get; set; }
        public string imageUrl { get; set; } = string.Empty;


    }
}
