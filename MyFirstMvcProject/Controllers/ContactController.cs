using Microsoft.AspNetCore.Mvc;
using MyFirstMvcProject.dtos;
using MyFirstMvcProject.Facades;

namespace MyFirstMvcProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController(ScheduleFacade scheduleFacade) : ControllerBase
    {
        private ScheduleFacade _scheduleFacade = scheduleFacade;
    }
}