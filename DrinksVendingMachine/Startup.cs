using DrinksVendingMachine.Interfaces;
using DrinksVendingMachine.Interfaces.Services;
using DrinksVendingMachine.Interfaces.Services.Drinks;
using DrinksVendingMachine.Models;
using DrinksVendingMachine.Models.Services;
using DrinksVendingMachine.Models.Services.Drinks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrinksVendingMachine
{
   public class Startup
   {
      public Startup (IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices (IServiceCollection services)
      {
         services.AddControllersWithViews();
         services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DVMDb")));

         services.AddScoped<ITypesDrinks, TypesDrinks>();
         services.AddScoped<IGroupsDrinks, GroupsDrinks>();
         services.AddScoped<IDrinks, Drinks>();

         services.AddScoped<IDrinksService, DrinksService>();
         services.AddScoped<ICoinService, CoinService>();
         services.AddScoped<IImageService, ImageService>();
         services.AddScoped<IPurchaseDrinksService, PurchaseDrinksService>();
         

         services.AddTransient<IChange, Change>();
         services.AddTransient<IAuthentication, BaseAuthentication>();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
         }
         app.UseStaticFiles();

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
