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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
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

            // устанавливаем адреса, которые будут обрабатыватьс€
            app.UseEndpoints(endponts =>
            {
                endponts.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cars}/{action=List}/{id?}");
            });

            AppDBContent content;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
            
        }
    }
}
