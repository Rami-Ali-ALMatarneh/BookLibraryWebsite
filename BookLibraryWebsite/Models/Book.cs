using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.Models
    {
    public class Book
        {
        [Required]
        [Key]
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal discount { get; set; }
        public string Created { get; set; }
        public KindOfBooks KindOfBooks { get; set; }
        }
    }
