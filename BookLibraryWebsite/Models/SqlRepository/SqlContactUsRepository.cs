using BookLibraryWebsite.Data;
using BookLibraryWebsite.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryWebsite.Models.SqlRepository
    {
    public class SqlContactUsRepository:IContactUsRepository
        {
        private readonly AppDbContext _context;
        public SqlContactUsRepository( AppDbContext _context )
            {
            this._context = _context;

            }

        public ContactUs AddMassage( ContactUs contactUs )
            {
            _context.ContactUs.Add( contactUs );
            _context.SaveChanges();
            return contactUs;
            }

        public ContactUs DeleteMassage( int id )
            {
            var massage = _context.ContactUs.Find(id);
            if ( massage != null )
                {
                _context.ContactUs.Remove( massage );   
                _context.SaveChanges();
                }
            return massage;
            }

        public IEnumerable<ContactUs> getAllMassages()
            {
            return _context.ContactUs;
            }

        public IEnumerable<ContactUs> GetMassageByEmail( string email )
            {
            return _context.ContactUs.Where(e => e.Email == email);
            }
        }
    }
