using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.Models
    {
    public class Schedule
        {
            public int Id { get; set; }
        [Required]
            public string Title { get; set; }
        [Required]

        public TimeSpan start { get; set; }
        [Required]

        public TimeSpan end { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        }
    }
