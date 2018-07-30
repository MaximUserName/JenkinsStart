using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<TaskDto> Get()
        {
            return new []
            {
                new TaskDto(){Name = "TaskOne"},
                new TaskDto(){Name = "TasTwo"},
                new TaskDto(){Name = "TaskThree"},
            };
        }
    }
}