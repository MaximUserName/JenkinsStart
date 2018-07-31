using System;
using Microsoft.EntityFrameworkCore;

namespace myapi.Controllers
{
    public class BlogContext : DbContext
    {
        // When used with ASP.net core, add these lines to Startup.cs
        //   var connectionString = Configuration.GetConnectionString("BlogContext");
        //   services.AddEntityFrameworkNpgsql().AddDbContext<BlogContext>(options => options.UseNpgsql(connectionString));
        // and add this to appSettings.json
        // "ConnectionStrings": { "BlogContext": "Server=localhost;Database=blog" }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString =
        //        "Server=postgre-test-db.c2sxohx0wlme.eu-west-3.rds.amazonaws.com;Port=5432;Database=catalogdb1;User Id=masterlogin;Password=*fzRFz2?;";

        //    optionsBuilder.UseNpgsql(connectionString, builder =>
        //        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
        //    base.OnConfiguring(optionsBuilder);
        //}

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}