using System.ComponentModel.DataAnnotations;

namespace NexusGames.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Invalid Name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Category> Categories { get; set; } = [];

        [Required(ErrorMessage = "Invalid Date")]
        public DateTime ReleaseDate { get; set; }

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [StringLength(250)]
        public string Author { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Url]
        public string imageUrl { get; set; } = string.Empty;
    }

}


