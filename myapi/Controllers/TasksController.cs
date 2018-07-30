using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Task> Get()
        {
            return _context.Tasks.ToList();
            return new []
            {
                new Task(){Name = "TaskOne"},
                new Task(){Name = "TasTwo"},
                new Task(){Name = "TaskThree"},
            };
        }
    }

    public class BlogContext : DbContext
    {
        // When used with ASP.net core, add these lines to Startup.cs
        //   var connectionString = Configuration.GetConnectionString("BlogContext");
        //   services.AddEntityFrameworkNpgsql().AddDbContext<BlogContext>(options => options.UseNpgsql(connectionString));
        // and add this to appSettings.json
        // "ConnectionStrings": { "BlogContext": "Server=localhost;Database=blog" }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }

}