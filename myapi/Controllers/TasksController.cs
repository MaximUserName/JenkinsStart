using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly BlogContext _context;

        public TasksController(BlogContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //List<Task> tasks = new List<Task>();
            try
            {
               var tasks = _context.Tasks.ToArray();
                return Ok(_context.Tasks);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            //return new []
            //{
            //    new Task(){Name = "TaskOne"},
            //    new Task(){Name = "TasTwo"},
            //    new Task(){Name = "TaskThree"},
            //};
        }
    }
}