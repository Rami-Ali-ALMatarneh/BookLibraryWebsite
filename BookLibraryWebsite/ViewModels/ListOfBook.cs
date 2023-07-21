﻿using BookLibraryWebsite.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.ViewModels
    {
    public class ListOfBook
        {
        public IEnumerable<Book> Books { get; set; }
        public Book book { get; set; }
        [Required]
        public KindOfBooks KindOfBooks { get; set; }
        public string TitleBook { get; set; }
        public IEnumerable<Schedule> scheduleTimes { get; set; }
        public AppUser appUser { get; set; }
        public AppUser carrentUser { get; set; }    
        public Cart Cart { get; set; }  
        public IEnumerable<Cart> carts { get; set; }
        }
    }
