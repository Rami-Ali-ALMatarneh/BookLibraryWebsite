using BookLibraryWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.ViewModels
    {
    public class HomeDetailsViewModel
        {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal discount { get; set; }
        public string Created { get; set; }
        public KindOfBooks KindOfBooks { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile pdfFile { get; set; }

        }
    }
