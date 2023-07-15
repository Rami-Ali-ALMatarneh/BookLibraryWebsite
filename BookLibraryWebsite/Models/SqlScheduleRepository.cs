using BookLibraryWebsite.Data;

namespace BookLibraryWebsite.Models
    {
    public class SqlScheduleRepository : IAlertRepository
        {
        private readonly AppDbContext appDbContext;
        public SqlScheduleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Schedule Addschedule( Schedule schedule )
            {
            var alert=appDbContext.Schedule.Add(schedule);
            appDbContext.SaveChanges();
            return (schedule);
            }

        public Schedule deleteSchedule( int scheduleId )
            {
            var alert = appDbContext.Schedule.Find(scheduleId);
            if( alert != null )
                {
                appDbContext.Schedule.Remove( alert );
                appDbContext.SaveChanges();
                }
            return alert;
            }

        public IEnumerable<Schedule> GetAllSchedule()
            {
            return appDbContext.Schedule;
            }

        public Schedule GetSchedule( int scheduleId )
            {
            return appDbContext.Schedule.Find( scheduleId);
            }
        }
    }
