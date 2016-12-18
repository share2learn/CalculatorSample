using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace CalculatorSample.Api.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

			services.AddSwaggerGen();

			services.ConfigureSwaggerGen(c =>
			{
				//Determine base path for the application.
				var basePath = PlatformServices.Default.Application.ApplicationBasePath;

				//Set the comments path for the swagger json and ui.
				var xmlPath = Path.Combine(basePath, "CalculatorSample.Api.Web.xml");
				c.IncludeXmlComments(xmlPath);
			});
			


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

			app.UseSwagger((request, doc) =>
			{
				// Set the title and description of the API.
				doc.Info = new Info
				{
					Title = "Math API",
					Description = "A simple math API for doing addition, subtraction, multiplication, and division",
					Version = "v1"
				};

				doc.Host = request.Host.Value;
				doc.Schemes = new[] { "http", "https" };
			});

			app.UseSwaggerUi();
        }
    }
}
