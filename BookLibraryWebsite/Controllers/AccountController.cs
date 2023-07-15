using BookLibraryWebsite.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWebsite.Controllers
    {
    public class AccountController : Controller
        {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser>userManager,SignInManager<IdentityUser>signInManager)
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
        public IActionResult Profile()
            {
            return View();
            }
        }
    }
