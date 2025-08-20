using Microsoft.AspNetCore.Mvc;
using schedule.server.facade;
using schedule.server.facade.dto;

namespace schedule.api.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController(ScheduleFacade scheduleFacade) : ControllerBase
    {
        private ScheduleFacade _scheduleFacade = scheduleFacade;

        [HttpPost]
        public IActionResult Create(ContactDto dto)
        {
            return Ok(_scheduleFacade.CreateContact(dto));
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        { 
            try{
                return Ok(_scheduleFacade.FindById(id));
            }
            catch(Exception)
            {
                return NotFound($"id: {id}");
            }
            
        } 
    }
}