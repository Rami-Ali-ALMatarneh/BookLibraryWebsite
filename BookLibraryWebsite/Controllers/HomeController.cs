using BookLibraryWebsite.Models;
using BookLibraryWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;



namespace BookLibraryWebsite.Controllers
    {
    public class HomeController : Controller
        {
        //inject IBookRepository & IWebHostEnvironment
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController( IBookRepository _bookRepository, IWebHostEnvironment _webHostEnvironment )
        {
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

        }
    }
