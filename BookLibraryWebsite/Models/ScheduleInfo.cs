namespace BookLibraryWebsite.Models
    {
    public class ScheduleInfo
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public TimeSpan start { get; set; }
            public TimeSpan end { get; set; }
        }
    }
