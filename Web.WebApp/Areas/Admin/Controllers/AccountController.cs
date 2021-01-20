using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Web.WebApp.Areas.Admin.ViewModel;
using Web.Data.Entities;
using Web.Data.DataContext;
using Web.Data.Model;

namespace Web.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/account")]
 
    
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly DataDbContext _context;
        public AccountController(UserManager<AppUser> userManager,DataDbContext context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        } 
        // GET: AccountController
       
        [HttpGet]
        
        [Route("register")]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]

        public async Task<IActionResult> Register(Data.Model.RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = register.Email,
                    Email = register.Email,
                };
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index","home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
                    return View(register);

        }
        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            Data.Model.LoginViewModel model = new Data.Model.LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins =
                (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(Data.Model.LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }

            }
            return View(model);
        }
        [HttpGet]
        [Route("detailsuser/{id}")]
        public async Task<IActionResult> DetailsUser(Guid? id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            return View(user);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(Guid? id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var model = new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,

            };
            return View(model);

        }
        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(UserViewModel app)
        {
            var user = await userManager.FindByIdAsync(app.Id.ToString());
            if (ModelState.IsValid)
            {
                user.FirstName = app.FirstName;
                user.UserName = app.Email;
                user.LastName = app.LastName;
                user.FullName = app.LastName + " " + app.FirstName;
                user.DateOfBirth = app.DateOfBirth;
                user.Gender = app.Gender;
                user.PhoneNumber = app.PhoneNumber;
                user.Address = app.Address;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Redirect("/account/detailsuser/" + app.Id);
                }
            }
            return View(app);
        }
        // This method added for role tutorial
        [HttpGet]
        [Route("access-denied")]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
