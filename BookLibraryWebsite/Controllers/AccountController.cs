using BookLibraryWebsite.Models;
using BookLibraryWebsite.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWebsite.Controllers
    {
    public class AccountController : Controller
        {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
            {
            return View();
            }
        /****************************************/
        [HttpPost]
        public async Task<IActionResult> login( LoginViewModel model)
            {
            if(ModelState.IsValid)
                {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,model.Rememberme,false);
                if(result.Succeeded)
                    {
                    return RedirectToAction("index", "home");
                    }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            return View(model);
            }
        /****************************************/
        [HttpPost]
        public async Task<IActionResult> logout()
            {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            }
        /****************************************/
        [HttpGet]
        public IActionResult Create()
            {
            return View();
            }
        /****************************************/
        [HttpPost]
        public async Task<IActionResult> Create(AppUser model)
            {
            if (ModelState.IsValid)
                {
                var user = new AppUser
                    {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password=model.Password,
                    phone = model.phone,
                    Language = model.Language,
                    Country = model.Country,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    ConfirmPassword=model.ConfirmPassword,
                    Major=model.Major,
                    };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Index", "Home");
                    }
                
                }
            return View(model);
            }
        /****************************************/
        public IActionResult Profile()
            {
            return View();
            }
        }
    }
