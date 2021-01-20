using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using Web.Application.MEvent;
using Web.Data.DataContext;
using Web.WebApp.Service.Event;

namespace Web.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/event")]
    [Authorize(Roles = "Admin,Staff")]
    public class EventController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IEventApiClient _eventApiClient;
        public EventController(DataDbContext context ,IEventApiClient eventApiClient)
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
        [HttpGet]
        [Route("create")]
        public  ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (EventRequest request)
        {
			try
			{

                if (request.nguoitoida < request.nguoitoithieu)
                {
                    ModelState.AddModelError("nguoitoida", "phải >= người tối thiểu");
                    return View();
                }
                else if (request.ngayketthuc < request.ngaybatdau)
                {
                    ModelState.AddModelError("ngayketthuc", "phải >= ngày bắt đầu");
                    return View();
                }

                else if (ModelState.IsValid)
				{	
                        // TODO: Add insert logic here 
                        var response = await _eventApiClient.Create(request);
                    

				}


				return RedirectToAction("Index");
			}
			catch
			{
                if (request.nguoitoida < request.nguoitoithieu)
                {
                    ModelState.AddModelError("nguoitoithieu", "Item1 + Item2 must be less than Item3");
                 
                }

                return View();
			}
		}
        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update(Guid ?id)
        {
            var response = await _eventApiClient.FindById(id);
            var model = JsonConvert.DeserializeObject<EventRequest>(response.ToString());

            return View(model);
        }
        [HttpPost]
        [Route("edit/{id}")] 
        public async Task<IActionResult> Update(EventRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var reponse = await _eventApiClient.Update(request);
                }
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
            var reponse = await _eventApiClient.FindById(id);
            var model = JsonConvert.DeserializeObject<EventRequest>(reponse.ToString());

            return View(model);
        }
        [Route("delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(EventRequest request)
        {
            try
            {
                // TODO: Add insert logic here 
                var response = await _eventApiClient.Delete(request);

                return RedirectToAction("Index");
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
            var reponse = await _eventApiClient.Details(id);
            var model = JsonConvert.DeserializeObject<EventResponse>(reponse.ToString());
            return View(model);
        }
    }
}
