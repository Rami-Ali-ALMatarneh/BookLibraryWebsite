using BookLibraryWebsite.Models;
using BookLibraryWebsite.Models.Repository;
using BookLibraryWebsite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment webHostEnvironment; 
        private readonly IContactUsRepository _contactUsRepository;

        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager, ICartRepository cartRepository, IBookRepository bookRepository,IWebHostEnvironment webHostEnvironment, IContactUsRepository _contactUsRepository )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.bookRepository = bookRepository;
            this.cartRepository = cartRepository;
            this.webHostEnvironment= webHostEnvironment;
            this._contactUsRepository = _contactUsRepository;
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

        public async Task<IActionResult> Create(AccountUserCreateViewModel model)
            {
            if (ModelState.IsValid)
                {
         
                var uniqueImg = string.IsNullOrEmpty(proccessUploadFileImg(model)) ? string.Empty : proccessUploadFileImg(model);
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
                    userType=model.userType,
                    photoPath= uniqueImg
                    // UserId = model.UserId,
                    };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                    }
                
                }
            return View(model);
            }
        /******************************************/
        private string proccessUploadFileImg( AccountUserCreateViewModel model )
            {
            string uniqueFileName = null;
            if (model.photoPath != null)
                {
                string uniqueUpload = Path.Combine(webHostEnvironment.WebRootPath, "ImageUser");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photoPath.FileName;
                string filePath = Path.Combine(uniqueUpload, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                    model.photoPath.CopyTo(fileStream);
                    }
                }
            return uniqueFileName;
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
                    userType=user.userType,
                    photoPath=user.photoPath,   
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
                    user.userType = appUser.userType;
                    user.photoPath=appUser.photoPath;
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
                    userType = appUser.userType,
                    photoPath=appUser.photoPath,
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
            if(Email=="admin1@gmail.com")
                {
                await _signInManager.SignOutAsync();
                }
            cartRepository.deleteAllCartByUserId(user.UserId);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index", "Home");
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> Cart(int BookId,string UserName)
            {
            var user = await _userManager.FindByNameAsync(UserName);
            var cartt = cartRepository.getCartById(BookId);
            if (cartt == null)
                {
                Cart cart = new Cart()
                    {
                    BookId = BookId,
                    UserId=user.UserId
                    };
                cartRepository.AddCart(cart);
                }
            return RedirectToAction("Index","Home");
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> listCart(string id)
            {
            var user =await _userManager.FindByNameAsync(id);   
            ListOfBook listOfBook = new ListOfBook
                {
                Books = bookRepository.getAllBooks(),
                carts = cartRepository.getAllByUserId(user.UserId),
                carrentUser=user
                };
            return View(listOfBook);
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> deleteCart(int Id,string userName )
            {
            var user = await _userManager.FindByNameAsync(userName);
            cartRepository.deleteCart(Id);
            return RedirectToAction("listCart", "Account",new {id= user.UserName });
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> ViewMassages()
            {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ListOfBook contactUs = new ListOfBook
                {
                ContactUs = _contactUsRepository.GetMassageByEmail(user.Email),
                };
            return View( contactUs);
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> DeleteMassage(int id)
            {
            _contactUsRepository.DeleteMassage(id);
            return RedirectToAction("ViewMassages","Account"); 
            }
        /********************************************************/
        [Authorize]
        public async Task<IActionResult> ViewUsers()
            {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(user.userType==UserType.Premium)
                {
                
                ListOfBook listOfBook = new ListOfBook
                    {
                    appUsers = _userManager.Users,
                    };
                return View(listOfBook);
                }
            return RedirectToAction("Profile","Account",new {id=user.UserName});
            }
        }
    }
