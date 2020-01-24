using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shop.Data;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repository;
using Shop.Data.Models;

namespace Shop
{

    /// <summary>
    /// TODO: Настроить валидацию формы оплаты
    ///     Подумать над добавлением возможности авторизации
    ///     Сделать приличный внешний вид а именно сделать нормальный футер и отредактировать хедер
    ///     Расширить саму базу данных и ассортиент автомобилий
    ///     Добавить возможность удаления машин из корзины
    ///     Подумать еще над логикой реализации проекта 
    ///     {
    ///         Оценить в целом проект
    ///         прочая фигня короче
    ///     }
    /// </summary>
    public class Startup
    {
        private IConfigurationRoot configurationString;

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

        // Метод регестрирующий различные модули и плагины
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
            //позволяет отображать стриницы с ошибками
            app.UseDeveloperExceptionPage();
            }

            // 100 200 300 400 500
            app.UseStatusCodePages();

            // Позволяет отображать статические файлы (картинки)
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            // Добавление возможности маршрутизации
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

            // устанавливаем адреса, которые будут обрабатываться
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
