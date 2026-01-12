using System;

namespace NexusGames.Models
{
    public class Gamer
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CreditCard { get; set; } = string.Empty;

        // שינינו מ-string ל-DateTime כדי שיתאים ל-DateTime.Now
        public DateTime DateOfBirth { get; set; }
    }
}
