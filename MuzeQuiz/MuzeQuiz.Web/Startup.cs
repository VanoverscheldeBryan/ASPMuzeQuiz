using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MuzeQuiz.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MuzeQuiz.Models;
using MuzeQuiz.Models.Data;
using MuzeQuiz.Models.Repositories;
using MuzeQuiz.Web.Data;

namespace MuzeQuiz.Web
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
            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddScoped<IQuestionRepo, QuestionRepo>();
            services.AddScoped<IAnswerRepo, AnswerRepo>();
            services.AddScoped<IRatingRepo, RatingRepo>();
            services.AddScoped<IDataInitializer, DataInitializer>();

            services.AddDbContext<DevDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DevDbContext>();
            services.Configure<IdentityOptions>(options => { options.Password.RequiredLength = 8; options.User.RequireUniqueEmail = true; options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30); });
            services.ConfigureApplicationCookie(options => { options.Cookie.HttpOnly = true; options.ExpireTimeSpan = TimeSpan.FromMinutes(30); });
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleMgr, UserManager<AppUser> userMgr)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            DevDbContextExtensions.SeedRoles(roleMgr).Wait();
            DevDbContextExtensions.SeedUsers(userMgr).Wait();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
