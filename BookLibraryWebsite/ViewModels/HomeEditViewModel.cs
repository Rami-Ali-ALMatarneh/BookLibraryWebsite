using BookLibraryWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.ViewModels
    {
    public class HomeEditViewModel
        {
            [Required]
            public string Title { get; set; }
            [Required]
            public string Description { get; set; }
            public float discount { get; set; }
            [Required]
            public float Price { get; set; }
            [Required]
            public DateTime Created { get; set; }
            [Required]
            public string author { get; set; }
            [Required]
            public string photo { get; set; }
            [Required]
            public string filePath { get; set; }
            [Required]
            public KindOfBooks KindOfBooks { get; set; }
        }
    }
