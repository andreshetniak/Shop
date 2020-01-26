using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;

namespace Shop
{
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IConfigurationRoot configurationString;

        public Startup(IWebHostEnvironment hostEnv)
        {
            configurationString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbSettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(configurationString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc().AddMvcOptions(s => s.EnableEndpointRouting = false);

            services.AddMemoryCache();
            services.AddSession();
        }

        // ћетод регестрирующий различные модули и плагины
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
            //позвол€ет отображать стриницы с ошибками
            app.UseDeveloperExceptionPage();
            }

            // 100 200 300 400 500
            app.UseStatusCodePages();

            // ѕозвол€ет отображать статические файлы (картинки)
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            // ƒобавление возможности маршрутизации
            app.UseRouting();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default", 
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "categoryFilter", 
                    template: "Car/{action}/{category?}", 
                    defaults: new { controller = "Car", action = "List" });
            });

            // устанавливаем адреса, которые будут обрабатыватьс€
            //app.UseEndpoints(endponts =>
            //{
            //    endponts.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Cars}/{action=List}/{id?}");
            //});

            AppDBContent content;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
            
        }
    }
}
