using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace myapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // var connectionString = Configuration.GetConnectionString("BlogContext");
            var connectionString =
                "Server=postgre-test-db.c2sxohx0wlme.eu-west-3.rds.amazonaws.com;Port=5432;Database=catalogdb;User Id=masterlogin;Password=*fzRFz2?;";
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<BlogContext>(options => options.UseNpgsql(connectionString));
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BlogContext context)
        {
            // https://abelsquidhead.com/index.php/2017/07/31/deploying-dbs-in-your-cicd-pipeline-with-ef-core-code-first/
            context.Database.Migrate();

            app.UseStaticFiles();
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // To get those from NGINX proxy server
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();

           
        }
    }
}
