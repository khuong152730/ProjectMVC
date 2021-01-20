using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Web.Application.MEvent;
using Web.Data.DataContext;
using Web.Data.Entities;
using Web.WebApp.Models;
using Web.WebApp.Service.Event;
using Web.WebApp.Service.Ticket;

namespace Web.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IEventApiClient _eventApiClient;
        private readonly ITicketApiClient ticketApiClient;
        public HomeController (DataDbContext context, IEventApiClient eventApiClient, ITicketApiClient ticketApiClient)
        {
            _context = context;
            _eventApiClient = eventApiClient;
            this.ticketApiClient = ticketApiClient;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var a = DateTime.Today;
            ViewBag.ListEvent = _context.Events.Where(x => x.ngayketthuc >= a).ToList();
            ViewBag.ListEvent2 = _context.Events.Where(x => x.ngayketthuc<= a ).ToList();
            return View();
        }
        [HttpGet]
        [Route("event/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid? id)
        {
            var reponse = await _eventApiClient.Details(id);
            ViewBag.Listticket = _context.Tickets.Where(x => x.EventId == id).ToList();
            var model = JsonConvert.DeserializeObject<EventResponse>(reponse.ToString());
            return View(model);
        }

        [HttpGet]
        [Route("datve/{ticketId}")]
        public ActionResult DatVe (Guid ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            ViewBag.ticketName = ticket.name;
            ViewBag.ticketId = ticketId;
            return View();
        }

        [HttpPost]
        [Route("datve/{ticketId}")]
        public async Task<ActionResult> DatVe(Participants participants)
        {
            if (ModelState.IsValid)
            {
                _context.Participants.Add(participants);
                await _context.SaveChangesAsync();
            }
            return Redirect("/");
        }


    }
}
