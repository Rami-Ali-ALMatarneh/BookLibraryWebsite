using BookLibraryWebsite.Models;
using BookLibraryWebsite.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookLibraryWebsite.Controllers
    {
    public class HomeController : Controller
        {
        //inject IBookRepository & IWebHostEnvironment
        private readonly IBookRepository _bookRepository;
        private readonly IAlertRepository _alertRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController( IBookRepository _bookRepository, IWebHostEnvironment _webHostEnvironment,IAlertRepository alertRepository )
        {
            this._alertRepository = alertRepository;
            this._bookRepository = _bookRepository;
            this._webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index( )
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
        public  IActionResult AddBook(HomeCreateViewModel model)
            {           
            if (ModelState.IsValid)
                {
                string uniqueFileImg = string.IsNullOrEmpty(proccessUploadFileImg(model)) ? string.Empty : proccessUploadFileImg(model);
                string uniqueFilePdf = string.IsNullOrEmpty(proccessUploadFilePdf(model)) ? string.Empty : proccessUploadFilePdf(model);
                
                Book books = new Book()
                    {
                    Title= model.Title,
                    Description= model.Description,
                    Price= model.Price,
                    discount= model.discount,
                    Created = model.Created,
                    author = model.author,
                    photoPath=uniqueFileImg,
                    KindOfBooks= model.KindOfBooks,
                    filePath= uniqueFilePdf
                    };
                _bookRepository.AddBook(books);
                return RedirectToAction("Index","Home");
                }       
            return View(model);
            }
        /************************************/
            [HttpGet]
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
        private string proccessUploadFileImg(HomeCreateViewModel model) {
            string uniqueFileName = null;
            if (model.photo != null)
                {
                string uniqueUpload = Path.Combine(_webHostEnvironment.WebRootPath, "ImagePage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;
                string filePath=Path.Combine(uniqueUpload, uniqueFileName);
                using(var fileStream= new FileStream(filePath, FileMode.Create))
                    {
                    model.photo.CopyTo(fileStream);
                    }
                }
            return uniqueFileName;
            }
        /*****************************************/
        private string proccessUploadFilePdf( HomeCreateViewModel model )
            {
            string uniqueFileName = null;
            if (model.filePath != null )
                {
                string uniqueUpload = Path.Combine(_webHostEnvironment.WebRootPath, "FilePdf");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.filePath.FileName;
                string filePath = Path.Combine(uniqueUpload, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                    model.filePath.CopyTo(fileStream);
                    }
                }
            return uniqueFileName;
            }
        /*****************************************/
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
        public IActionResult Search(ListOfBook model)
            {
            if (model.KindOfBooks == KindOfBooks.AllBooks && model.TitleBook == null)
                {
                return RedirectToAction("Store", "Home");
                }
            else
                {
                       ListOfBook listOfBook = new ListOfBook()
                        {
                        KindOfBooks = model.KindOfBooks,
                        Books = _bookRepository.GetBookByKindOfBooks(model.KindOfBooks),
                        };
                    return View(listOfBook);
                }
            }
        /****************************************/
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


        public IActionResult AboutUs()
            {
            return View();
            }          
        /****************************************/
        public IActionResult Profile()
            {
            return View();
            }
        /****************************************/
        [HttpGet]
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

        [HttpPost]
        public IActionResult Schedule(ScheduleTimes model)
            {
            if (ModelState.IsValid)
                {
                Schedule schedule = new Schedule()
                    {
                    Title = model.Title,
                    start = model.start,
                    end = model.end
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
        public IActionResult Login()
            {
            return View();
            }       
        /****************************************/

        public IActionResult RestPassword()
            {
            return View();
            }
        /****************************************/

        public IActionResult CreateBasic()
            {
            return View();
            }
        /****************************************/

        public IActionResult CreateContact()
            {
            return View();
            }
        /****************************************/

        public IActionResult CreatePrivacy()
            {
            return View();
            }

        /****************************************/
        //public IActionResult Cart()
        //    {
        //    return View();

        //    }
        }
    }
