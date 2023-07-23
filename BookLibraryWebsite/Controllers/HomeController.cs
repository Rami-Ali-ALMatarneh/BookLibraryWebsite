using BookLibraryWebsite.Models;
using BookLibraryWebsite.Models.Repository;
using BookLibraryWebsite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace BookLibraryWebsite.Controllers
{
    [Authorize]
    public class HomeController : Controller
        {
        //inject IBookRepository & IWebHostEnvironment
        private readonly IBookRepository _bookRepository;
        private readonly IAlertRepository _alertRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IContactUsRepository _contactUsRepository;
        public HomeController( IBookRepository _bookRepository, IWebHostEnvironment _webHostEnvironment,IAlertRepository alertRepository, UserManager<AppUser>userManager,SignInManager<AppUser>signInManager,IContactUsRepository _contactUsRepository )
        {
            this._signInManager=signInManager;
            this._userManager=userManager;
            this._alertRepository = alertRepository;
            this._bookRepository = _bookRepository;
            this._webHostEnvironment = _webHostEnvironment;
            this._contactUsRepository = _contactUsRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
            {
            var getAllBook =_bookRepository.getAllBooks();
            var kindOfBook = new KindOfBooks();
            var listOfBooks = new ListOfBook()
                {
                Books = getAllBook,
                KindOfBooks = kindOfBook
                };
            return View( listOfBooks );
            }
        /************************************/
        [HttpGet]
        public IActionResult AddBook(  )
            {
            return View();
            }
        [HttpPost]
        public  async Task<IActionResult> AddBook(HomeCreateViewModel model,string name)
            {           
            if (ModelState.IsValid)
                {
                //string uniqueFileImg = string.IsNullOrEmpty(proccessUploadFileImg(model)) ? string.Empty : proccessUploadFileImg(model);
                //string uniqueFilePdf = string.IsNullOrEmpty(proccessUploadFilePdf(model)) ? string.Empty : proccessUploadFilePdf(model);
                var user=await _userManager.FindByNameAsync(name);
                float finalPrice = 0;
                if (model.discount > 0)
                    {
                    model.oldPrice = model.Price;
                    model.Price =model.Price-( model.Price - ( (model.discount / 100) * model.Price));
                    }
                else
                    {
                    model.oldPrice = 0;
                    }
                Book books = new Book()
                    {
                    oldPrice= model.oldPrice,
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    discount = model.discount,
                    Created = model.Created,
                    author = model.author,
                    photoPath = string.IsNullOrEmpty(proccessUploadFileImg(model.photo)) ? string.Empty : proccessUploadFileImg(model.photo),
                    KindOfBooks = model.KindOfBooks,
                    filePath = string.IsNullOrEmpty(proccessUploadFilePdf(model.filePath)) ? string.Empty : proccessUploadFilePdf(model.filePath),
                    AppUserId= user.UserId
                    };
                _bookRepository.AddBook(books);
                return RedirectToAction("Index","Home");
                }       
            return View(model);
            }
        /************************************/
            [HttpGet]
        [AllowAnonymous]
        public IActionResult Store()
            {
            var getAllBook = _bookRepository.getAllBooks();
            var kindOfBook = new KindOfBooks();
            var ListOfBooks = new ListOfBook()
                {
                Books = getAllBook,
                KindOfBooks=kindOfBook
                };
            ViewBag.BooksKind = "All Book";
            return View(ListOfBooks);
            }
        [HttpGet]
        [AllowAnonymous]

        public IActionResult StoreList()
            {
            var getAllBook = _bookRepository.getAllBooks();
            var kindOfBook = new KindOfBooks();
            var ListOfBooks = new ListOfBook()
                {
                Books = getAllBook,
                KindOfBooks = kindOfBook
                };
            ViewBag.BooksKind = "All Book";
            return View(ListOfBooks);
            }

        /************************************/
        [Route("/home/Store/{id}")]
        [AllowAnonymous]

        public IActionResult BooksKind(KindOfBooks id )
            {
            if(id == KindOfBooks.AllBooks)
                {
                return RedirectToAction("Store", "Home");
                }
            var bookByKind = _bookRepository.GetBookByKindOfBooks(id);
            var kindsOfBooks=new KindOfBooks();
            var ListOfBook = new ListOfBook()
                {
                Books = bookByKind,
                KindOfBooks = kindsOfBooks
                };
            return View(ListOfBook);
            }
        /**********************************/
        private string proccessUploadFileImg(IFormFile model) {
            string uniqueFileName = null;
            if (model != null)
                {
                string uniqueUpload = Path.Combine(_webHostEnvironment.WebRootPath, "ImageBook");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                string filePath=Path.Combine(uniqueUpload, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                    model.CopyTo(fileStream);
                    }
                }
            return uniqueFileName;
            }
        /*****************************************/
        private string proccessUploadFilePdf( IFormFile model )
            {
            string uniqueFileName = null;
            if (model != null )
                {
                string uniqueUpload = Path.Combine(_webHostEnvironment.WebRootPath, "FilePdf");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                string filePath = Path.Combine(uniqueUpload, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                    model.CopyTo(fileStream);
                    }
                }
            return uniqueFileName;
            }
        /*****************************************/
        [AllowAnonymous]

        public IActionResult News()
            {
            DateTime Year = new DateTime();
            var Books=_bookRepository.getAllBooks();
            var KindOfBook = new KindOfBooks();
            var list = new ListOfBook()
                {
                Books = Books,
                KindOfBooks = KindOfBook,
                };
            return View(list);
            }
        /****************************************/
        [AllowAnonymous]
        public IActionResult Search(ListOfBook model)
            {
            if (model.KindOfBooks == KindOfBooks.AllBooks && model.TitleBook == null)
                {
                return RedirectToAction("Store", "Home");
                }
            else
                {
                if(model.TitleBook!=null)
                    {
                    ListOfBook listOfBook = new ListOfBook()
                        {
                        KindOfBooks = model.KindOfBooks,
                        Books = _bookRepository.GetAllBooksByTitle(model.TitleBook),
                        };
                    return View(listOfBook);
                    }
                ListOfBook listOfBook1 = new ListOfBook()
                        {
                        KindOfBooks = model.KindOfBooks,
                        Books = _bookRepository.GetBookByKindOfBooks(model.KindOfBooks),
                        };
                    return View(listOfBook1);
                }
            }
        /****************************************/
        [AllowAnonymous]
        public IActionResult Details(int id )
            {
            Book book = _bookRepository.GetBook(id);
            if (book != null)
                {
                ListOfBook ListOfBooks = new ListOfBook()
                    {
                    book = book,
                    };
                return View(ListOfBooks);
                }
            else
            {
               return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode= (int)HttpStatusCode.NotFound });
                }
            }
        /****************************************/

        [AllowAnonymous]

        public IActionResult AboutUs()
            {
            return View();
            }          
     
        /****************************************/
        [HttpGet]
        [AllowAnonymous]

        public IActionResult Schedule()
            {
            //var getAllAlert = _alertRepository.GetAllSchedule();
            //ScheduleTimes scheduleTimes = new ScheduleTimes()
            //    {
            //    schedules = getAllAlert,
            //    };
            return View();
            }
        /****************************************/
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Schedule( Alrets model,string Name )
            {
            if (ModelState.IsValid)
                {
                var user = await _userManager.FindByNameAsync(Name);
                Schedule schedule = new Schedule()
                    {
                    Title = model.Title,
                    start = model.start,
                    end = model.end,
                    AppUserId = user.UserId
                    };
                _alertRepository.Addschedule(schedule);
                return RedirectToAction("Alert", "Home");
                }
            return View();
            }
        /****************************************/
        public IActionResult Alert()
            {
            var allAlert = _alertRepository.GetAllSchedule();
            ListOfBook listOfBook = new ListOfBook()
                {
                scheduleTimes = allAlert
                };
            return View(listOfBook);
            }
        /****************************************/
        public IActionResult deleteAlert( int id)
            {
            var alert = _alertRepository.GetSchedule(id);
            if (alert != null)
                {
                _alertRepository.deleteSchedule(id);
                }
                  else
                    {
                    return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = (int)HttpStatusCode.NotFound });
                    }
            return RedirectToAction("Alert","Home");
            }
        /****************************************/
        [HttpGet]
        public IActionResult UpdateBook(int id)
            {
            var bookk=_bookRepository.GetBook(id);
            ListOfBook books = new ListOfBook()
                {
              book=bookk
                };
            return View(books);
            }
        /****************************************/
        [HttpPost]
        public async Task<IActionResult> UpdateBook( ListOfBook model)
            {
            model.book.photoPath = model.photo.Name;
            model.book.filePath = model.filePath.Name;
         
                //string uniqueFileImg = string.IsNullOrEmpty(proccessUploadFileImg(model)) ? string.Empty : proccessUploadFileImg(model);
                //string uniqueFilePdf = string.IsNullOrEmpty(proccessUploadFilePdf(model)) ? string.Empty : proccessUploadFilePdf(model);
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                float finalPrice = 0;
                if (model.book.discount > 0)
                    {
                    model.book.Price = model.book.Price - ((model.book.discount / 100) * model.book.Price);
                    }
                Book books = new Book()
                    {
                    Id=model.book.Id,
                    Title = model.book.Title,
                    Description = model.book.Description,
                    Price = model.book.Price,
                    discount = model.book.discount,
                    Created = model.book.Created,
                    author = model.book.author,
                    photoPath = string.IsNullOrEmpty(proccessUploadFileImg(model.photo)) ? string.Empty : proccessUploadFileImg(model.photo),
                    KindOfBooks = model.KindOfBooks,
                    filePath = string.IsNullOrEmpty(proccessUploadFilePdf(model.filePath)) ? string.Empty : proccessUploadFilePdf(model.filePath),
                    AppUserId = user.UserId
                    };
                _bookRepository.UpdateBook(books);
                return RedirectToAction("Index", "Home");
            }
        /****************************************/
        public IActionResult DeleteBook( int id, string name )
            {
            var book = _bookRepository.GetBook(id);
            if (book != null)
                {
                _bookRepository.DeleteBook(id);
                }
            return RedirectToAction("Library", "Account", new { id = name });
            }
        /****************************************/
        [HttpGet]
        public IActionResult ContactUs()
            {
            return View();
            }
        /****************************************/
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUs model)
            {          
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            model.Name = user.FullName;
            model.Email = user.Email;            
                if (ModelState.IsValid)
                {
                ContactUs contactUs = new ContactUs()
                    {
                    Name = model.Name,
                    Email = model.Email,
                    Descrption = model.Descrption,
                    };
                _contactUsRepository.AddMassage(contactUs);
                }
            return View();
            }
        /****************************************/
        //public IActionResult Cart()
        //    {
        //    return View();

        //    }
        }
    }
