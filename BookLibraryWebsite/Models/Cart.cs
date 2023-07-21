using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.Models
    {
    public class Cart
        {
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; } 

        }
    }
