using BookLibraryWebsite.Models;
using BookLibraryWebsite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWebsite.Controllers
    {
    public class AccountController : Controller
        {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBookRepository bookRepository;
        private readonly ICartRepository cartRepository;
        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager, ICartRepository cartRepository, IBookRepository bookRepository )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.bookRepository = bookRepository;
            this.cartRepository = cartRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
            {
            return View();
            }
        /****************************************/
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> login( LoginViewModel model,string returnUrl = null )
            {
            if(ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                    // Login successful
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (Url.IsLocalUrl(returnUrl) && !String.IsNullOrEmpty(returnUrl))
                        {
                        if(returnUrl== "/Account/Library")
                            {
                        return LocalRedirect(returnUrl+"/"+user.UserName);
                            }
                        else
                          if (returnUrl == "/Account/Profile")
                            {
                            return LocalRedirect(returnUrl + "/" + user.UserName);
                            }
                        else
                            {
                            return LocalRedirect(returnUrl);
                            }
                        }
                    else
                        {
                        return RedirectToAction("index", "home");
                        }
                    }
                return View(model);
                //ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            return View(model);
            }
        /****************************************/
        [Route("logout")]
        [Authorize] 
        public async Task<IActionResult> logout()
            {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            }
        /****************************************/
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
            {
            return View();
            }
        /****************************************/
        [HttpPost]
        [AllowAnonymous]

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
                   // UserId = model.UserId,
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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile(string id)
            {
            var user=await _userManager.FindByNameAsync(id);
            if(user != null)
                {
                var ListOfBook = new ListOfBook
                    {
                    appUser=new AppUser
                        {
               
                    FullName = user.FullName,
                    Major = user.Major,
                    Language = user.Language,
                    Gender= user.Gender,
                    phone=user.phone,
                    Country=user.Country,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    ConfirmPassword= user.ConfirmPassword,
                 }
                    };
                return View(ListOfBook);
                }
            return RedirectToAction("HttpStatusCodeHandler", "Error",404);
            }
        /****************************************/
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(AppUser appUser)
            {
            if(ModelState.IsValid)
                {
                var user = await _userManager.FindByEmailAsync(appUser.Email);
                if(user != null)
                    {
                    user.FullName = appUser.FullName;
                    user.Major = appUser.Major;
                    user.Language = appUser.Language;
                    user.Gender = appUser.Gender;
                    user.phone = appUser.phone;
                    user.Country = appUser.Country;
                    user.UserName = appUser.UserName;
                    user.Email = appUser.Email;
                    user.Password=appUser.Password;
                    user.ConfirmPassword = appUser.ConfirmPassword;
                    var result = await _userManager.UpdateAsync(user);
                    if(result.Succeeded)
                        {
                    return RedirectToAction("Index", "Home");
                        }
                    }
                }
            var ListOfBook = new ListOfBook
                {
                appUser = new AppUser
                    {

                    FullName = appUser.FullName,
                    Major = appUser.Major,
                    Language = appUser.Language,
                    Gender = appUser.Gender,
                    phone = appUser.phone,
                    Country = appUser.Country,
                    UserName = appUser.UserName,
                    Email = appUser.Email,
                    Password = appUser.Password,
                    ConfirmPassword = appUser.ConfirmPassword,
                    }
                };
            return View(ListOfBook);
            }
        /***************************************************/
        [AllowAnonymous]
        [HttpGet]
        public IActionResult RestPassword()
            {
            return View();
            }
        /********************************************************/
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RestPassword(RestPassword model)
            {
            if (ModelState.IsValid)
                {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user!=null)
                    {
                    user.Password = model.Password;
                    user.ConfirmPassword= model.ConfirmPassword;  
                   var result= await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        {
                        if (_signInManager.IsSignedIn(User))
                            {
                            return RedirectToAction("Index", "Home");
                            }
                        else
                            {
                        return RedirectToAction("Login", "Account");
                            }
                        }
                }
                }
            return View();
            }
        /********************************************************/
        [Authorize]
    public async Task<IActionResult> Library(string id )
            {
            var user = await _userManager.FindByNameAsync(id);
            if (user!=null)
                {
                var book = bookRepository.GetBooksByUserId(user.UserId);
                ListOfBook listOfBook = new ListOfBook
                    {
                    Books=book,
                    };
                return View(listOfBook);
                }
            return View();
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> deleteUser( string Email )
            {
            var user = await _userManager.FindByEmailAsync(Email);
            await _signInManager.SignOutAsync();
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index", "Home");
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> Cart(int BookId)
            {
            var cartt = cartRepository.getCartById(BookId);
            if (cartt == null)
                {
                Cart cart = new Cart()
                    {
                    BookId = BookId
                    };
                cartRepository.AddCart(cart);
                }
            return RedirectToAction("Index","Home");
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> listCart()
            {
            ListOfBook listOfBook = new ListOfBook
                {
                Books = bookRepository.getAllBooks(),
                carts = cartRepository.getAllCart()
                };
            return View(listOfBook);
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> deleteCart(int id)
            {
            cartRepository.deleteCart(id);
            return RedirectToAction("listCart", "Account");
            }
        }
    }
