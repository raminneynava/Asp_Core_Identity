using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Asp_Core_Identity.Data;
using Asp_Core_Identity.Models;
using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asp_Core_Identity
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
            services.AddDbContext<DataBaseContext>(x => x.UseSqlServer("Data Source=.;Initial Catalog=AspCoreIdentity;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddIdentity<User, Role>()
              .AddEntityFrameworkStores<DataBaseContext>()
              .AddDefaultTokenProviders()
              .AddRoles<Role>()
              .AddErrorDescriber<CustomIdentityError>();


            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("Admin");
                });
            });


            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireDigit= false;
                opt.Password.RequireLowercase= false;
                opt.Password.RequireNonAlphanumeric= false;
                opt.Password.RequireUppercase= false;
                opt.Password.RequiredLength= 6;
                opt.Password.RequiredUniqueChars= 1;
                //lockout
                opt.Lockout.MaxFailedAccessAttempts= 5;
                opt.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(10);
                //singin
                opt.SignIn.RequireConfirmedAccount= false;
                opt.SignIn.RequireConfirmedEmail= false;
                opt.SignIn.RequireConfirmedPhoneNumber= false;
            });
            services.ConfigureApplicationCookie(option => {

                option.ExpireTimeSpan= TimeSpan.FromMinutes(60);
                option.LoginPath = "/account/login";
                option.AccessDeniedPath = "/account/404";
                option.SlidingExpiration = true;
            });
            services.AddRazorPages();
             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
