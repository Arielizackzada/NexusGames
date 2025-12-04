namespace NexusGames.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int GamerId { get; set; }
        public int GameId { get; set; }

        
    }
    public class CartItem
    {
        public int GameId { get; set; }
        public int Id { get; set; }
    }
}
