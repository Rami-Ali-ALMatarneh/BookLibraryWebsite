using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.Models
    {
    public class Book
        {
        [Required]
        [Key]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public float Price { get; set; }

        public float discount { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string photoPath { get; set; }
        [Required]
        public string filePath { get; set; }
        [Required]
        public KindOfBooks KindOfBooks { get; set; }
        }
    }
