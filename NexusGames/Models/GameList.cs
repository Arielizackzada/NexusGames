namespace NexusGames.Models
{
    public class GameList
    {
        public int Id { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();
        public int GamerId { get; set; }
        public Gamer Gamer { get; set; } = new Gamer();
        

    }
}
