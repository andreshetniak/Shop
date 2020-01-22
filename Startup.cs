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

namespace Shop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAllCars, MockCars>();
            services.AddTransient<ICarsCategory, MockCategory>();
            services.AddMvc();
        }

        // ����� �������������� ��������� ������ � �������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
            //��������� ���������� �������� � ��������
            app.UseDeveloperExceptionPage();
            }

            // 100 200 300 400 500
            app.UseStatusCodePages();

            // ��������� ���������� ����������� ����� (��������)
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            // ���������� ����������� �������������
            app.UseRouting();
            app.UseAuthorization();

            // ������������� ������, ������� ����� ��������������
            app.UseEndpoints(endponts =>
            {
                endponts.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cars}/{action=List}/{id?}");
            });
        }
    }
}
