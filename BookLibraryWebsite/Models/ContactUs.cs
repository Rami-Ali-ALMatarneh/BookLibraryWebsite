using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.Models
    {
    public class ContactUs
        {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Required]
        [MaxLength(300)]
        public string Descrption { get; set; }
        }
    }
