using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public SystemController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_environment);
        }
    }

    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly BlogContext _context;
        private readonly IHostingEnvironment _environment;

        public TasksController(BlogContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(_environment);
            //List<Task> tasks = new List<Task>();
            try
            {
                throw new NullReferenceException("jsdljfsldjflsdf");
               var tasks = _context.Tasks.ToArray();
                return Ok(tasks);
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