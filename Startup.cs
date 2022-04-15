using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment12_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Assignment12_1
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
            //services.AddSingleton<IProductRepository, ProductRepository>(); //registers the service
            services.AddScoped<IProductRepository, DBData>(); //added to 
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(@$"Server=LAPTOP-U6HHMD8I\SQLEXPRESS; Database=ProductsAssignment; Trusted_Connection=True; MultipleActiveResultSets=True"));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<UserContext>();
            services.AddDbContext<UserContext>(options => options.UseSqlServer(@$"Server=LAPTOP-U6HHMD8I\SQLEXPRESS; Database=AssignmentUsers; Trusted_Connection=True; MultipleActiveResultSets=True"));
        }

        static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] rolenames = { "Admin", "Employee" };
            foreach (var rolename in rolenames)
            {
                bool roleExists = await roleManager.RoleExistsAsync(rolename);
                if(!roleExists)
                {
                    IdentityRole role= new IdentityRole();
                    role.Name = rolename;
                    IdentityResult result = await roleManager.CreateAsync(role);
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProductContext productContext, UserContext userContext)
        {
            //creates the database
            userContext.Database.EnsureCreated();
            productContext.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction())
            {
                app.UseExceptionHandler("/Error.html");
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

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
