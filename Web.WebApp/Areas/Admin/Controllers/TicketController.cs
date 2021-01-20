using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.Application.MTicket;
using Web.Data.DataContext;
using Web.WebApp.Service.Ticket;

namespace Web.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/ticket")]
    [Authorize(Roles = "Admin,Staff")]
    public class TicketController : Controller
    {
        private readonly DataDbContext _context;
        private readonly ITicketApiClient _ticketApiClient;
        public TicketController(DataDbContext context, ITicketApiClient ticketApiClient)
        {
            _context = context;
            _ticketApiClient = ticketApiClient;
        }
        // GET: EventController
        [Route("index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var reponse = await _ticketApiClient.GetAll();
            var model = JsonConvert.DeserializeObject<List<TicketReponse>>(reponse);
            return View(model);
        }
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "id", "sukien");
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(TicketRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here 
                    ViewData["EventId"] = new SelectList(_context.Events, "id", "sukien", request.EventId);
                    var response = await _ticketApiClient.Create(request);


                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(Guid? id)
        {
            var response = await _ticketApiClient.FindById(id);
            ViewData["EventId"] = new SelectList(_context.Events, "id", "sukien");
           
            var model = JsonConvert.DeserializeObject<TicketRequest>(response.ToString());
            return View(model);
        }
        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(TicketRequest request)
        {
            try
            {
                ViewData["EventId"] = new SelectList(_context.Events, "id", "sukien", request.EventId);
                var response = await _ticketApiClient.Update(request);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var response = await _ticketApiClient.FindById(id);
            var model = JsonConvert.DeserializeObject<TicketReponse>(response.ToString());
            return View(model);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(TicketRequest request)
        {
            try
            {
                var response = await _ticketApiClient.Delete(request);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            var response = await _ticketApiClient.Details(id);
            var model = JsonConvert.DeserializeObject<TicketReponse>(response.ToString());
            return View(model);
        }

    }
}

