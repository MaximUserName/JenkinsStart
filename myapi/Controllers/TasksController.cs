using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<Task> tasks = new List<Task>();
            try
            {
                tasks = _context.Tasks.ToList();
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

    public class BlogContext : DbContext
    {
        // When used with ASP.net core, add these lines to Startup.cs
        //   var connectionString = Configuration.GetConnectionString("BlogContext");
        //   services.AddEntityFrameworkNpgsql().AddDbContext<BlogContext>(options => options.UseNpgsql(connectionString));
        // and add this to appSettings.json
        // "ConnectionStrings": { "BlogContext": "Server=localhost;Database=blog" }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Server=postgre-test-db.c2sxohx0wlme.eu-west-3.rds.amazonaws.com;Port=5432;Database=catalogdb;User Id=masterlogin;Password=*fzRFz2?;";

            optionsBuilder.UseNpgsql(connectionString);
            //  base.OnConfiguring(optionsBuilder);
        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }

}