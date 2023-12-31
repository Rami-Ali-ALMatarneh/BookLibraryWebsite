﻿using BookLibraryWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.ViewModels
    {
    public class HomeCreateViewModel
        {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0, 100)]
        public float discount { get; set; }
        [Required]
        [Range(1, 100)]
        public float Price { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string author { get; set; }
        public float oldPrice { get; set; }

        [Required]
        public IFormFile? photo { get; set; }
        [Required]
        public IFormFile? filePath { get; set; }
        [Required]
        public KindOfBooks KindOfBooks { get; set; }
        public int UserId { get; set; }
        [Required]
        public UserType userType { get; set; }

        }
    }
