using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //bu metod ile proje seviyesinde  Authorize iþlemi kullanabilicez
            services.AddMvc(config =>
            {
                //policy newleyip authantice iþlemini zorunlu kýlan bir metod yazýcaz
                var policy=new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser() //kullanýcý otantike olmasý 
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";  //return url yapacagýmýz sayfanýn dizinini verdik.
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");  //code={0} hata kodu için almasý gereken kod deðeridir
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            //uygulama ayaða kaldýrýldýðý zaman ilk çalýsacak kýsýmdýr burasý.(canlýya aldýgýmýzda falan..)
            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllerRoute(  //areas açýnca bunu buraya yapýstýrdýk(scafoldingreadme içinden alýp).
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
             );

                 endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
