using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cascade.Challenges.Books.Mvc
{
    using Models;
    using Models.Data;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void OnAddDbContext<TContext>(DbContextOptionsBuilder options)
            where TContext : DbContext
        {
            var connectionString = Configuration.GetConnectionString(nameof(BooksDbContext));
            options.UseSqlServer(connectionString);
        }

        private static IEnumerable<BookCitationFormatProvider> GetBookCitationFormatProviders(IServiceProvider provider)
        {
            yield return provider.GetRequiredService<ChicagoBookCitationFormatProvider>();
            yield return provider.GetRequiredService<MlaBookCitationFormatProvider>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: TBD: for now singleton, let's see if that works...
            services.AddSingleton<BooksDataGenerator>();
            services.AddDbContext<BooksDbContext>(OnAddDbContext<BooksDbContext>);

            services.AddTransient<ChicagoBookCitationFormatProvider>();
            services.AddTransient<MlaBookCitationFormatProvider>();

            // When we need a range of all of the format providers
            services.AddTransient(GetBookCitationFormatProviders);
            services.AddTransient(provider => GetBookCitationFormatProviders(provider).ToArray());

            services.AddControllersWithViews();
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

            app.UseHttpsRedirection();
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
