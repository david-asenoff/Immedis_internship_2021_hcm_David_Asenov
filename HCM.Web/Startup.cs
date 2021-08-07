namespace HCM.Web
{
    using HCM.Data.Common;
    using HCM.Data;
    using HCM.Data.Seeding;
    using HCM.Services;
    using HCM.Services.Contracts;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<ApplicationDbContext>(
               options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Login";
                    options.Cookie.Name = GlobalConstants.AuthenticationCookieName;
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });
            services.AddMvc();

            // Application services
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IPaymentIntervalService, PaymentIntervalService>();
            services.AddTransient<IEvaluationScoreService, EvaluationScoreService>();
            services.AddTransient<IMaritalStatusService, MaritalStatusService>();
            services.AddTransient<IParentalStatusService, ParentalStatusService>();
            services.AddTransient<ITrainingService, TrainingService>();
            services.AddTransient<IProjectStatusCategoryService, ProjectStatusCategoryService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IProjectService, ProjectService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This using ensures that in Development mode migrations will be automaticaly apllied and the data will be seeded on the application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }


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


            // To say who you are, to give your username and password, or facebook login
            app.UseAuthentication();

            // To receive the permission to do something, to get a role as a admin or user
            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
