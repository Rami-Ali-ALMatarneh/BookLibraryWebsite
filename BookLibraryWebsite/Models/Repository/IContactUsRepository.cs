namespace BookLibraryWebsite.Models.Repository
    {
    public interface IContactUsRepository
        {
        public IEnumerable<ContactUs> getAllMassages();
        public ContactUs AddMassage( ContactUs contactUs );
        public ContactUs DeleteMassage( int id );
        public IEnumerable<ContactUs> GetMassageByEmail( string email );
        }
    }
