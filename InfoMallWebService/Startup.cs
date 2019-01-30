using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InfoMallWebService.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InfoMallWebService.Models;
using InfoMallWebService.Repository;
using InfoMallWebService.Services;

namespace InfoMallWebService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public static IConfiguration Configuration { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddDefaultUI(UIFramework.Bootstrap4)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			//services for repositories
			services.AddTransient<IBannerRepository, BannerInfoRepository>();
			services.AddTransient<ICategoryForInfoRepository, CategoryForInfoRepository>();
			services.AddTransient<ICategoryForTabRepository, CategoryForTabRepository>();
			services.AddTransient<IClienteleRepository, ClienteleRepository>();
			services.AddTransient<IContactInfoRepository, ContactInfoRepository>();
			services.AddTransient<IContentForMallRepository, ContentForMallRepository>();
			services.AddTransient<IContentForTabRepository, ContentForTabRepository>();
			services.AddTransient<IContentImageRepository, ContentImageRepository>();
			services.AddTransient<ICustomerProductRepository, CustomerProductRepository>();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<IPromotionCustomerRepository, PromotionCustomerRepository>();
			services.AddTransient<IPromotionInfoRepository, PromotionInfoRepository>();
			services.AddTransient<IPromotionRepository, PromotionRepository>();

			//Services for email and images
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddTransient<IImageService, ImageService>();


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
