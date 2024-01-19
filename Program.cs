using EmployeeManagement.Models;
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

            ///making the IEmployeeRepository implemnted By MockEmployeeRepositroy
            ///as a service, so that it's implemented once in here as singleton

            builder.Services.AddSingleton<IEmployeeRepository,MockEmployeeRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {

                //app.UseDeveloperExceptionPage();



                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
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