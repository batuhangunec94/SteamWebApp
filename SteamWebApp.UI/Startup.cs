using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.BLL.Entity.Concrete;
using SteamWebApp.DAL.Entity.Abstraction;
using SteamWebApp.DAL.Entity.Concrete.EfCore;
using SteamWebApp.DAL.Entity.Concrete.EfCore.Context;
using SteamWebApp.Entities.Entity.Concrete;
using SteamWebApp.UI.IdentityEntities;
using SteamWebApp.UI.Midllewares;

namespace SteamWebApp.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ProjectContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<ICommentDal, EfCommentDal>();
            //services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IGameRepository, EfGameRepository>();
            services.AddScoped<IGameService, GameManager>();
            services.AddScoped<IGameUserService, GameUserManager>();
            services.AddScoped<IGameUserRepository, EfGameUserRepository>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentRepository, EfCommentRepository>();
            //services.AddScoped<IUserDal, EfUserDal>();
            //services.AddScoped<IUserService, UserManager>();

            services.AddMvc(x => x.EnableEndpointRouting = false);


            services.Configure<IdentityOptions>(x =>
            {
                
                x.Password.RequiredLength = 5;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;



                x.Lockout.MaxFailedAccessAttempts = 5;
                x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                x.Lockout.AllowedForNewUsers = true;

                //x.User.AllowedUserNameCharacters = "";
                x.User.RequireUniqueEmail = true;


                x.SignIn.RequireConfirmedEmail = false;

                });

            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = "/account/login";
                x.LogoutPath = "/account/logout";
                x.AccessDeniedPath = "/account/accessdenied";
                x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                x.SlidingExpiration = true;
                x.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name=".SteamWebApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "adminGames",
                        template: "admin/game",
                        defaults: new { controller = "Admin", action = "ListGame" }
                    );
                routes.MapRoute(
                        name: "adminEditGames",
                        template: "admin/game/{id?}",
                        defaults: new { controller = "Admin", action = "EditGame" }
                    );
                routes.MapRoute(
                        name: "adminEditCategories",
                        template: "admin/category/{id?}",
                        defaults: new { controller = "Admin", action = "EditCategory" }
                    );
                routes.MapRoute(
                        name: "games",
                        template: "games/{category?}",
                        defaults: new { controller = "Home", action = "List" }
                    );
                routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });

            SeedIdentity.Seed(userManager, roleManager, Configuration).Wait();

        }
        //System.AggregateException: 'Some services are not able to be constructed'
    }
}
