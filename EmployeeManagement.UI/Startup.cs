using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.BusinessEngine.Implementation;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.Mappings;
using EmployeeManagement.Data.Contacts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;
using EmployeeManagement.Data.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI
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
            services.AddRazorPages();
            services.AddDbContext<ProjectEmployeeManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddAutoMapper(typeof(Maps));

            services.AddIdentity<Employee, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ProjectEmployeeManagementContext>();


            // services.AddScoped<IEmployeeLeaveAllocationRepository, EmployeeLeaveAllocationRepository>();
            //services.AddScoped<IEmployeeLeaveRequestRepository, EmployeeLeaveRequestRepository>();
            //services.AddScoped<IEmployeeLeaveTypeRepository, EmployeeLeaveTypeRepository>();
            services.AddScoped<IEmployeeLeaveTypeBusinessEngine, EmployeeLeaveTypeBusinessEngine>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddMvc();
            
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            SeedData.Seed(userManager, roleManager);

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=EmployeeLeaveType}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
