using AutoMapper;
using Google.Api.Gax.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sjx_Mvc.Models;
using SjxLogistics.Components;
using SjxLogistics.Data;
using SjxLogistics.DTOs;
using SjxLogistics.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sjx_Mvc
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
            services.AddControllersWithViews();
            services.AddSession();
           



            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    
            // services.AddIdentity<IdentityUser, IdentityRole>(
            //options => options.User.AllowedUserNameCharacters = null);
            services.AddDistributedMemoryCache();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "Account/login";
                options.LogoutPath = "Account/logout";
            });

         

            // IdentityBuilder builder = services.AddIdentityCore<IdentityUser>(options =>
            // {
            //     options.Password.RequireDigit = false;
            //     options.Password.RequireLowercase = true;
            //     options.Password.RequiredLength = 8;
            // });
            // builder.AddSignInManager<SignInManager<IdentityUser>>();
            //builder.AddEntityFrameworkStores<DataBaseContext>();



            services.AddSession(options => {
               
     
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.Cookie.IsEssential = true;
            });
          
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
