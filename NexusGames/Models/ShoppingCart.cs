namespace NexusGames.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int GamerId { get; set; }
        public Gamer? Gamer { get; set; }

        public bool IsPurchased { get; set; } = false;
        public int TotalPrice { get; set; } = 0;

        public List<CartItem> CartItems { get; set; } = new();
    }

    
    
        public class CartItem
        {
            public int Id { get; set; }

            public int ShoppingCartId { get; set; }
            public ShoppingCart ShoppingCart { get; set; }

            public int GameId { get; set; }
            public Game Game { get; set; }
        }
    }


