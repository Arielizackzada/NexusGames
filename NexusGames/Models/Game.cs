using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NexusGames.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? CategoryId { get; set; }  

        public Category? Category { get; set; } 

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        [Column(TypeName = "decimal(18,2)")]

        public decimal Price { get; set; }

        public string imageUrl { get; set; }
    }
}




