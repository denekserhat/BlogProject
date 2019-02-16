using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BlogProject.API
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
            string connection = @"Server=DESKTOP-LDVGTNI\SQLEXPRESS;Database=BlogProject;Trusted_Connection=True;MultipleActiveResultSets=true";
            //db connection
            services.AddDbContext<BlogContext>(x => x.UseSqlServer(connection, b=> b.MigrationsAssembly("BlogProject.API")));
            //created for dependency injection
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped(typeof(UserManager));
            services.AddScoped(typeof(BlogContext));
            services.AddTransient<MyInitiliazer>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options => {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                  .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                  ValidateIssuer = false,
                  ValidateAudience = false
              };
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MyInitiliazer seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           // seeder.Seed();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
