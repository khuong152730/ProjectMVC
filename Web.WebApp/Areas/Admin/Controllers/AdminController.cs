using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Application.MEvent;
using Web.Data.DataContext;
using Web.WebApp.Service.Event;

namespace Web.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/home")]
    [Route("admin")]
    [Authorize(Roles = "Admin,Staff")]
    public class AdminController : Controller
    {
          private readonly DataDbContext _context;
        private readonly IEventApiClient _eventApiClient;
        public AdminController(DataDbContext context ,IEventApiClient eventApiClient)
        {
            _context = context;
            _eventApiClient = eventApiClient;
        }

        // GET: EventController
        [Route("index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var reponse = await _eventApiClient.GetAll();
            var model = JsonConvert.DeserializeObject<List<EventResponse>>(reponse);
            return View(model);
        }
    }
}
