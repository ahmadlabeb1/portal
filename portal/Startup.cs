using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portal.Data;
using portal.services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace portal
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
            
            services.AddScoped<ILanguageServices, LanguageServices>();
            services.AddScoped<ILocalizationService, Localization>();
            services.AddDbContext<PortalContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PortalContext")));
            services.AddLocalization();
            services.AddControllersWithViews().AddViewLocalization();
            var servicesProvider = services.BuildServiceProvider();
            var LanguageServices = servicesProvider.GetRequiredService<ILanguageServices>();
            var language = LanguageServices.GetLanguage();
            var culture = language.Select(x => new CultureInfo(x.Lang_key)).ToArray();
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var arabicLangKey = culture.FirstOrDefault(a => a.Name == "ar");
                opt.DefaultRequestCulture = new RequestCulture(arabicLangKey?.Name ?? "ar");
                opt.SupportedCultures = culture;
                opt.SupportedUICultures = culture;
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
                app.UseHsts();
            }
            app.UseRequestLocalization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "adminAreas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
