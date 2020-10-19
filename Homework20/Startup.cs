using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework20.Context;
using Homework20.Data;
using Homework20.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Homework20
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавление использования контекста данных
            services.AddDbContext<DataContext>();

            services.AddTransient<Ipers, PersApi>();

            // Добавление использования архетектуры MVC
            services.AddMvc(
                mvcOptions =>
                {
                    mvcOptions.EnableEndpointRouting = false;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Добавление возможности использования статических файлов
            app.UseStaticFiles();

            // Настройка маршрутизации
            app.UseMvc(
                route =>
                {
                    route.MapRoute("default", "{Controller=Index}/{Action=Index}");
                });
        }
    }
}
