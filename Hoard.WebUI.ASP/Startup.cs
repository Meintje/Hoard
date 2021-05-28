using Hoard.Infrastructure.Persistence.DataAccess;
using Hoard.Core.Interfaces.Games;
using Hoard.Core.Interfaces.Wishlist;
using Hoard.WebUI.ASP.Data;
using Hoard.WebUI.Services;
using Hoard.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoard.Infrastructure.Persistence.Services;
using Hoard.Infrastructure.Persistence.Services.Games;
using Hoard.Infrastructure.Persistence.Services.Wishlist;
using Hoard.WebUI.Services.Converters;
using System.Globalization;
using Hoard.WebUI.Services.Services;
using Hoard.Infrastructure.Persistence.Services.Journal;
using Hoard.Core.Interfaces.Journal;

namespace Hoard.WebUI.ASP
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<HoardDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HoardConnection")).EnableSensitiveDataLogging());
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IGameDbService, GameDbService>();
            services.AddScoped<IGenreDbService, GenreDbService>();
            services.AddScoped<IPlatformDbService, PlatformDbService>();
            services.AddScoped<IPlayDataDbService, PlayDataDbService>();
            services.AddScoped<IPlaythroughDbService, PlaythroughDbService>();
            services.AddScoped<IPlayStatusDbService, PlayStatusDbService>();
            services.AddScoped<IPriorityDbService, PriorityDbService>();
            services.AddScoped<IOwnershipStatusDbService, OwnershipStatusDbService>();
            services.AddScoped<ILanguageDbService, LanguageDbService>();
            services.AddScoped<IMediaTypeDbService, MediaTypeDbService>();
            services.AddScoped<ISeriesDbService, SeriesDbService>();
            services.AddScoped<IModeDbService, ModeDbService>();
            services.AddScoped<IDeveloperDbService, DeveloperDbService>();
            services.AddScoped<IPublisherDbService, PublisherDbService>();

            services.AddScoped<IWishlistDbService, WishlistDbService>();
            services.AddScoped<IWishlistItemTypeDbService, WishlistItemTypeDbService>();

            services.AddScoped<IJournalDbService, JournalDbService>();
            services.AddScoped<ITagDbService, TagDbService>();


            services.AddScoped<IGameViewService, GameViewService>();
            services.AddScoped<IPlayDataViewService, PlayDataViewService>();
            services.AddScoped<IUserDashboardViewService, UserDashboardViewService>();

            services.AddScoped<IWishlistViewService, WishlistViewService>();

            services.AddScoped<IJournalViewService, JournalViewService>();

            services.AddScoped<IConverter, HTMLConverter>();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            string defaultCulture = "en-UK";
            var cultureInfo = new CultureInfo(defaultCulture);
            cultureInfo.NumberFormat.CurrencySymbol = "€";
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
                {
                    context.Request.Path = "/Error/404";
                    await next();
                }
            });

            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // TODO: Add middleware that inserts a different DbContext is the user is a Guest

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
