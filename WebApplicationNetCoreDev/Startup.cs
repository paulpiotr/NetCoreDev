using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NetAppCommon;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            PortalApiGusApiRegonData.Models.AppSettings portalApiGusApiRegonDataAppSettings = PortalApiGusApiRegonData.Models.AppSettings.GetInstance();
            services.AddDbContext<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>(options => options.UseSqlServer(NetAppCommon.DatabaseMssql.ParseConnectionString(portalApiGusApiRegonDataAppSettings.GetConnectionString())));

            ApiWykazuPodatnikowVatData.Models.AppSettings apiWykazuPodatnikowVatDataAppSettings = ApiWykazuPodatnikowVatData.Models.AppSettings.GetInstance();
            services.AddDbContext<ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext>(options => options.UseSqlServer(NetAppCommon.DatabaseMssql.ParseConnectionString(apiWykazuPodatnikowVatDataAppSettings.GetConnectionString())));
            
            //To do
            //services.AddDbContextPool<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>(options => options.UseSqlServer(PortalApiGusApiRegonData.PortalApiGusApiRegonDataContext.GetConnectionString()));

            services.AddAuthentication().AddCookie(
                    options =>
                    {
                        options.AccessDeniedPath = "/Authentication/AccessDenied";
                        options.Cookie.Name = Assembly.GetExecutingAssembly().GetName().Name;
                        options.Cookie.HttpOnly = true;
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                        options.LoginPath = "/Authentication";
                        options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                        options.SlidingExpiration = true;
                    }
                )
                .AddJwtBearer("Bearer", CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        LifetimeValidator = (before, expires, token, param) =>
                        {
                            return expires > DateTime.UtcNow;
                        },
                        //ClockSkew = TimeSpan.FromMinutes(5),
                        RequireSignedTokens = true,
                        RequireExpirationTime = true,
                        //ValidateIssuer = true,
                        ValidateIssuer = false,
                        //ValidateAudience = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        //ValidIssuer = Configuration["TokenProviderOptions:Issuer"],
                        //ValidAudience = Configuration["TokenProviderOptions:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EncryptDecrypt.EncryptDecrypt.GetRsaFileContent("id_rsa.ppk.pub")))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Query.ContainsKey("AccessToken"))
                            {
                                context.Token = context.Request.Query["AccessToken"];
                            }
                            return Task.CompletedTask;
                        }
                    };
                })
            ;
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            services.AddAuthorization();
            services.AddKendo();
            services.AddControllers().AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    options.SerializerSettings.Formatting = Formatting.Indented;
                }
            );
            services.AddControllersWithViews().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                }
            );
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            CookiePolicyOptions cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };
            app.UseCookiePolicy(cookiePolicyOptions);
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            NetAppCommon.HttpContextAccessor.AppContext.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            await NetAppCommon.Helpers.EntityContextHelper.RunMigrationAsync<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>(app.ApplicationServices).ConfigureAwait(false);
            await NetAppCommon.Helpers.EntityContextHelper.RunMigrationAsync<ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext>(app.ApplicationServices).ConfigureAwait(false);
            //await NetAppCommon.Helpers.EntityContextHelper.RunMigrationAsync<IUIntegrationSystemData.Data.IUIntegrationSystemDataDbContext>(app.ApplicationServices).ConfigureAwait(false);
        }
    }
}