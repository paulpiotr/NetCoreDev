using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApplicationNetCoreDev
{
    public class Startup
    {
        #region private readonly log4net.ILog _log4Net
        // <summary>
        // Referencja klasy Log4NetLogger
        // Reference to the Log4NetLogger class
        // </summary>
        private readonly log4net.ILog _log4Net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);
        #endregion

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews(options =>
                // System sprawdzania poprawności w programie .NET Core 3,0 lub nowszy traktuje parametry niedopuszczające wartości null lub właściwości powiązane tak, jakby miały [Required] atrybut. - Wyłączenie
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            try
            {
                // Kontekst bazy danych PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext
                var portalApiGusApiRegonDataAppSettings = PortalApiGusApiRegonData.Models.AppSettings.GetInstance();
                services.AddDbContext<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>(options => options.UseSqlServer(portalApiGusApiRegonDataAppSettings.GetConnectionString()));
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            try
            {
                // Kontekst bazy danych ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext
                var apiWykazuPodatnikowVatDataAppSettings = ApiWykazuPodatnikowVatData.Models.AppSettings.GetInstance();
                services.AddDbContext<ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext>(options => options.UseSqlServer(apiWykazuPodatnikowVatDataAppSettings.GetConnectionString()));
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            try
            {
                // Kontekst bazy danych WebconIntegrationSystem.Data.BPSMainAttDbContext.BPSMainAttDbContext
                var webconIntegrationSystemAppSettings = WebconIntegrationSystem.Models.BPSMainAtt.AppSettings.GetInstance();
                services.AddDbContext<WebconIntegrationSystem.Data.BPSMainAttDbContext.BPSMainAttDbContext>(options => options.UseSqlServer(webconIntegrationSystemAppSettings.GetConnectionString()));
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            try
            {
                // Kontekst bazy danych Vies.Core.Database.Data.ViesCoreDatabaseContext
                var viesCoreDatabaseAppSettings = Vies.Core.Database.Models.AppSettings.GetInstance();
                services.AddDbContextPool<Vies.Core.Database.Data.ViesCoreDatabaseContext>(options => options.UseSqlServer(viesCoreDatabaseAppSettings.GetConnectionString(), element => element.EnableRetryOnFailure()));
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

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
                        LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
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
                            if (context != null && context.Request.Query.ContainsKey("AccessToken"))
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
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            var cookiePolicyOptions = new CookiePolicyOptions
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

            // Important Add HttpContextAccessor
            NetAppCommon.HttpContextAccessor.AppContext.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            #region Migracja bazy danych
            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext
                    NetAppCommon.Helpers.EntityContextHelper.RunMigrationAsync<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>(app.ApplicationServices).Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                }
            }).Wait();
            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext
                    NetAppCommon.Helpers.EntityContextHelper.RunMigrationAsync<ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext>(app.ApplicationServices).Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                }
            }).Wait();
            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych Vies.Core.Database.Data.ViesCoreDatabaseContext
                    NetAppCommon.Helpers.EntityContextHelper.RunMigrationAsync<Vies.Core.Database.Data.ViesCoreDatabaseContext>(app.ApplicationServices).Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                }
            }).Wait();
            #endregion
        }
    }
}
