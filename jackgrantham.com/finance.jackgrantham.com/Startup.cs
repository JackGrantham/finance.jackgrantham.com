using finance.jackgrantham.com.Data;
using Going.Plaid;
using library.jackgrantham.com.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace finance.jackgrantham.com
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Repositories
            services.AddControllers();

            // Plaid
            services.AddMvc(o => o.EnableEndpointRouting = false);
            services.AddHttpClient();
            services.Configure<PlaidCredentials>(_config.GetSection(PlaidOptions.SectionKey));
            services.Configure<PlaidOptions>(_config.GetSection(PlaidOptions.SectionKey));
            services.AddSingleton<PlaidClient>();

            // Default Services
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // Additional Services
            services.AddDbContext<FinanceDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("finance.jackgrantham.com")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMvcWithDefaultRoute();
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
