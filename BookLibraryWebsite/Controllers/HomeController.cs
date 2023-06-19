using BookLibraryWebsite.Models;
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
        public IActionResult Index()
            {
            return View();
            }
        }
    }
