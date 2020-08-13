using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzeQuiz.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;
using MuzeQuiz.Models.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MuzeQuiz.Models;
using Microsoft.AspNetCore.Identity;

namespace MuzeQuiz.API
{
    public class Startup
    {

        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //1.1 loophandling verhinderen

            services.AddMvc(options => { options.EnableEndpointRouting = false; options.RespectBrowserAcceptHeader = true; options.Filters.Add(new ConsumesAttribute("application/json")); }).AddNewtonsoftJson(options =>
            {
                //circulaire referenties verhinderen door navigatie props
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });



            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DevDbContext>(options => options.UseSqlServer(connectionString));


            //cookies authenticatie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
               options =>
               {
                   options.Cookie.SameSite = SameSiteMode.None;
                   options.Events =
                     new CookieAuthenticationEvents()
                     {
                         OnRedirectToLogin = (ctx) =>
                         {
                             if (ctx.Request.Path.StartsWithSegments("/api") &&
                        ctx.Response.StatusCode == 200) //redirect naar loginURL is 200
                             {
                                 //doe geen redirect naar een loginpagina bij een api call 
                                 //maar geef een 401 (unauthorized) als authenticatie faalt 
                                 ctx.Response.StatusCode = 401;
                                 ctx.Response.WriteAsync("{\"error\": " + ctx.Response.StatusCode + " Geen toegang}");
                             }

                             return Task.CompletedTask;
                         }
                     };
               });

            services.AddCors();


            // registratie van repos
            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddScoped<IQuestionRepo, QuestionRepo>();
            services.AddScoped<IAnswerRepo, AnswerRepo>();

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DevDbContext>();

            //open API documentatie
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Security_API", Version = "v1.0" });
            });

            //5. HSTS & HTTPS-Redirection in production met opties
            if (!env.IsDevelopment())
            {
                services.AddHttpsRedirection(options =>
                {
                    //default: 307 redirect
                    // options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                    options.HttpsPort = 443;
                });

                services.AddHsts(options =>
                {
                    options.MaxAge = TimeSpan.FromDays(40); //default 30
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DevDbContext context, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(cfg => { cfg.AllowAnyHeader().AllowAnyMethod();});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //configuratie openAPI documentatie
            app.UseSwagger(); //enable swagger
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger"; //path naar de UI pagina: /swagger/index.html
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Security_API v1.0");
            });
        }
    }
}
