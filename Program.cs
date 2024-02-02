using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EmployeeManagement
{
    public class Program
    {
        private IConfiguration _config;

        public Program(IConfiguration config)
        {
                    _config=config;
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            // Add services to the container.
            builder.Services.AddControllersWithViews();//.AddXmlSerializerFormatters();
            builder.Services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));
            ///making the IEmployeeRepository implemnted By MockEmployeeRepositroy
            ///as a service, so that it's implemented once in here as singleton

            builder.Services.AddScoped<IEmployeeRepository,SQLEmployeeRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {

                //app.UseDeveloperExceptionPage();



                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }else
            {
				app.UseExceptionHandler("/Home/Error");
				app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseHttpsRedirection();
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();
             
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}