using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SigmaCoreEmpty
{
    public class Startup
    {
       
        IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
        //    var loggerFile = loggerFactory.CreateLogger("FileLogger");
        //    loggerFactory.AddConsole();
        //    // если приложение в процессе разработки
            //if (env.IsDevelopment())
            //{
            //    // то выводим информацию об ошибке, при наличии ошибки
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // установка обработчика ошибок
            //    app.UseExceptionHandler("/Home/Error");
            //}

//    //app.Run(async (context) =>
//    //{
//    //    await context.Response.WriteAsync("Hello World!");
//    //});
//    app.Run(async (context) =>
//    {
//        loggerFile.LogInformation("Processing request {0}", context.Request.Path);
//        // создаем объект логгера
//        var logger = loggerFactory.CreateLogger("RequestInfoLogger");
//        // пишем на консоль информацию
//        logger.LogInformation("Processing request {0}", context.Request.Path);

//        //await context.Response.WriteAsync(_env.ApplicationName);

//    });
//    // установка обработчика статических файлов
//    app.UseStaticFiles();
//    // установка GDPR
//    app.UseCookiePolicy();
//    // Установка компонентов MVC для обработки запроса
//    app.UseMvc(routes =>
//    {
//        routes.MapRoute(
//            name: "default",
//            template: "{controller=Home}/{action=Index}/{id?}");
//    });
//}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.Map("/index", Index);
            //app.Map("/about", About);
            //app.Map("/add", add);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Page Not Found");
            //});
            //int x = 5;
            //int y = 8;
            //int z = 0;
            //app.Use(async (context, next) =>
            //{
            //    z = x * y;
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"x * y = {z}");
            //});
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // установка обработчика ошибок
                app.UseExceptionHandler("index");
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute("index", "index", new { controller = "Animals", action = "Index" });

                routes.MapRoute("add", "add/animals/{name}&{weight}&{height}", new { controller = "Animals", action = "Add"});
              //  routes.MapRoute("add", "add/{name?}&{height?}&{weight?}", new { controller = "Animals", action = "Add" });


            });
        }

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }

        private static void add(IApplicationBuilder app)
        {
            //Repository repository=new Repository(new SqlConnection());
            //            repository.AddAnimals();
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Animals");
            });
        }

    }
}
