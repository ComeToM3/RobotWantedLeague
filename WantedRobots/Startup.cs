//Startup.cs

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using WantedRobots.Models;


public class Startup
{
    private readonly IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();



        services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        Configuration.GetConnectionString("DefaultConnection"),
        new MariaDbServerVersion(new Version(10, 5, 12)));


});
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Robot}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
            name: "DeleteRobot",
            pattern: "Robot/Delete/{id}",
            defaults: new { controller = "Robot", action = "Delete" }
);


        });
    }
}
