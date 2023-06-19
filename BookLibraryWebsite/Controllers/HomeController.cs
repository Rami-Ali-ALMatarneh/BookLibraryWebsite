using BookLibraryWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWebsite.Controllers
    {
    public class HomeController : Controller
        {
        //inject IBookRepository & IWebHostEnvironment
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IActionResult Index()
            {
            return View();
            }
        }
    }
