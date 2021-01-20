using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Application.MEvent;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _service;
        public EventController(IEventService service)
        {
            _service = service;
        }
        //get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }
        //get
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] EventRequest request)
        {
            return Ok(await _service.Create(request));
        }
        //post 
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] EventRequest request)
        {
            return Ok(await _service.Update(request));
        }
        //post 
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] EventRequest request)
        {
            return Ok(await _service.Delete(request));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            return Ok(await _service.Details(id));
        }
        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(Guid? id)
        {
            return Ok(await _service.FindById(id));
        }
    }
}
