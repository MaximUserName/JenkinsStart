using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace myapi.Controllers
{
    public class DesignTimeDbConextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            var env = "Development";
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddJsonFile($"appsettings.{env}.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BlogContext>();
            var connectionString = configuration.GetConnectionString("BlogContext");

            builder.UseNpgsql(connectionString);

            return new BlogContext(builder.Options);
        }
    }
}