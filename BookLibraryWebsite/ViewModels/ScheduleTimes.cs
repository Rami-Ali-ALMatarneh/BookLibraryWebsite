
using BookLibraryWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.ViewModels
    {
    public class ScheduleTimes
        {
        [Required]
        public string Title { get; set; }
        [Required]

        public TimeSpan start { get; set; }
        [Required]

        public TimeSpan end { get; set; }
        }
    }
