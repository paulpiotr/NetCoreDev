using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace WebApplicationNetCoreDev
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
            //options.DefaultChallengeScheme = IISDefaults.AuthenticationScheme;
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            //services.AddAuthentication(options => {
            //    options.DefaultChallengeScheme = IISDefaults.AuthenticationScheme;
            //});
            //string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            //%AppDomain.CurrentDomain.BaseDirectory%

            if (null != Configuration.GetConnectionString("AdvertisingCampaignContext") && Configuration.GetConnectionString("AdvertisingCampaignContext").Contains("%AppDomain.CurrentDomain.BaseDirectory%"))
            {

                //string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                //string baseDirectoryDatabaseMdf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\AdvertisingCampaignContext.mdf");
                //string baseDirectoryDatabaseLogLdf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\AdvertisingCampaignContext_log.ldf");
                //string applicationDataDatabaseMdf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Assembly.GetExecutingAssembly().GetName().Name, "AdvertisingCampaignContext.mdf");
                //string applicationDataDatabaseLogLdf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Assembly.GetExecutingAssembly().GetName().Name, "AdvertisingCampaignContext.ldf");
                //if (
                //    File.Exists(baseDirectoryDatabaseMdf) &&
                //    File.Exists(baseDirectoryDatabaseLogLdf) &&
                //    !File.Exists(applicationDataDatabaseMdf) &&
                //    !File.Exists(applicationDataDatabaseLogLdf)
                //    )
                //{
                //    dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Assembly.GetExecutingAssembly().GetName().Name);
                //    Directory.CreateDirectory(dataDirectory);
                //    File.Copy(baseDirectoryDatabaseMdf, applicationDataDatabaseMdf);
                //    File.Copy(baseDirectoryDatabaseLogLdf, applicationDataDatabaseLogLdf);
                //}
                //else if (File.Exists(applicationDataDatabaseMdf) && File.Exists(applicationDataDatabaseLogLdf))
                //{
                //    dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Assembly.GetExecutingAssembly().GetName().Name);
                //}
                //AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);

                AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
                services.AddDbContext<AdvertisingCampaign.Models.AdvertisingCampaignContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AdvertisingCampaignContext").Replace("%AppDomain.CurrentDomain.BaseDirectory%", AppDomain.CurrentDomain.BaseDirectory)));
            }
            else if (null != Configuration.GetConnectionString("AdvertisingCampaignContext"))
            {
                //AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
                services.AddDbContext<AdvertisingCampaign.Models.AdvertisingCampaignContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AdvertisingCampaignContext")));
            }

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                    options =>
                    {
                        options.AccessDeniedPath = "/Authentication/AccessDenied";
                        options.Cookie.Name = Assembly.GetExecutingAssembly().GetName().Name;
                        options.Cookie.HttpOnly = true;
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                        options.LoginPath = "/Authentication";
                        // ReturnUrlParameter requires 
                        //using Microsoft.AspNetCore.Authentication.Cookies;
                        options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                        options.SlidingExpiration = true;
                    }
                );
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("Administrator"));
                options.AddPolicy("User", policy => policy.RequireClaim("User"));
            });

            //services.AddAuthentication(IdentityServerConstants.ExternalCookieAuthenticationScheme).AddCookie();
            //services.AddAuthentication().AddOpenIdConnect("idsrv.external", "IdentityServer", options =>
            // {
            //     options.RequireHttpsMetadata = false;
            //     options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //     options.SignOutScheme = IdentityServerConstants.SignoutScheme;
            //     options.Authority = "/Authentication";
            //     options.ClientId = "implicit";
            //     //options.ResponseType = "id_token";
            //     //options.SaveTokens = true;
            //     //options.CallbackPath = new PathString("/signin-idsrv");
            //     //options.SignedOutCallbackPath = new PathString("/signout-callback-idsrv");
            //     //options.RemoteSignOutPath = new PathString("/signout-idsrv");
            //     options.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         NameClaimType = "name",
            //         RoleClaimType = "role"
            //     };
            // });
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
            app.UseAuthentication();
            CookiePolicyOptions cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };
            app.UseCookiePolicy(cookiePolicyOptions);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseIdentityServer();
        }
    }
}
