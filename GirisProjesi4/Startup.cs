using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GirisProjesi4
{
    public class Startup
    {
        public static int ID = 0;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            //app.UseBrowserLink();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // bu metot çağrılmazssa "Bu sayfa çalışmıyor" hatasından başka bir bilgi alamayız. Bu normalde kullanıcılara olası bir hatada kullanılması gereken bir sayfa.
            } //hata durumunda detaylı bilgi almak için bu sayfayı çağırdık.

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routeBuild => routeBuild.MapRoute(name: "default2", template: "{controller=Anasayfa}/{action=Index}/{id?}"));
        }
    }
}
