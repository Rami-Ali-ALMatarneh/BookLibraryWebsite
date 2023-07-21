namespace BookLibraryWebsite.Models.Repository
{
    public interface IAlertRepository
    {
        public IEnumerable<Schedule> GetAllSchedule();
        public Schedule deleteSchedule(int scheduleId);
        public Schedule GetSchedule(int scheduleId);
        public Schedule Addschedule(Schedule schedule);
    }
}
