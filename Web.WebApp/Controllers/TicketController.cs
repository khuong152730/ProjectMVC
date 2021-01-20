using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web.Application.MTicket;
using Web.Data.DataContext;
using Web.Data.Entities;
using Web.Data.Model;
using Web.WebApp.Service.Ticket;

namespace Web.WebApp.Controllers
{

    public class TicketController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly DataDbContext _context;
        private readonly ITicketApiClient ticketApiClient;
        public TicketController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, DataDbContext context,ITicketApiClient ticketApiClient)
        {
            this.ticketApiClient = ticketApiClient;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
        }
        [HttpGet]
        [Route("danh-sach-ve")]
        public async Task<IActionResult> ListTicket(Guid ? id)
        {
            ViewBag.ListTicket = _context.Tickets.Where(x => x.EventId ==id).ToList();
            return View();
        }
      

        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id.ToString());

        
               

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

               

                return View(model);
            }
        }

        //[HttpGet]
        //[Route("new")]
        //public async Task<IActionResult> Test(Guid? id)
        //{

        //    var user = await userManager.FindByIdAsync(id.ToString());
        //    var model = new UserViewModel
        //    {

        //        Id = user.Id,
        //        Email = user.Email,
        //        UserName = user.UserName,
        //};

        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Test(UserViewModel model)
        //{
        //    var user = await userManager.FindByIdAsync(model.Id.ToString());

        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
        //        return View();
        //    }
        //    else
        //    {
        //        user.Email = model.Email;
        //        user.UserName = model.UserName;
        //        ViewData["EventId"] = new SelectList(_context.Events, "id", "name", model.TicketId);

        //        var result = await userManager.UpdateAsync(user);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }

        //        return View(model);
        //    }
        //}

    }   
  

    


