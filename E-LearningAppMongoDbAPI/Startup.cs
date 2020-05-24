using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LearningAppMongoDbAPI.Models;
using E_LearningAppMongoDbAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace E_LearningAppMongoDbAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            // requires using Microsoft.Extensions.Options
            services.Configure<E_LearningDatabaseSettings>(
                Configuration.GetSection(nameof(E_LearningDatabaseSettings)));

            services.AddSingleton<IE_LearningDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<E_LearningDatabaseSettings>>().Value);

            services.AddSingleton<UserService>(); //adding Singleton UserService
            services.AddSingleton<CourseService>(); //adding Singleton CourseService
            services.AddSingleton<SchoolService>(); //adding Singleton SchoolService
            services.AddSingleton<CategoryService>(); //adding Singleton CategoryService
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
