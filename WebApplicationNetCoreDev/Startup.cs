#region using

using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApiWykazuPodatnikowVatData.Data;
using log4net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NetAppCommon.Extensions.DependencyInjection;
using NetAppCommon.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PortalApiGus.ApiRegon.DataBase.Data;
using PortalApiGus.ApiRegon.DataBase.Models;
using Vies.Core.Database.Data;
using Knf.DataBase.Models;
using Knf.DataBase.Data;
using WebconIntegrationSystem.Data.BPSMainAttDbContext;
using AppSettings = PortalApiGus.ApiRegon.DataBase.Models.AppSettings;

#endregion

namespace WebApplicationNetCoreDev
{
    public class Startup
    {
        #region private readonly log4net.ILog _log4Net

        // <summary>
        // Referencja klasy Log4NetLogger
        // Reference to the Log4NetLogger class
        // </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //#region Insights
            //// https://docs.microsoft.com/pl-pl/azure/azure-monitor/app/asp-net-core AddApplication Insights
            //services.AddApplicationInsightsTelemetry();
            //#endregion

            //#region DistributedMemoryCache
            //services.AddNetAppCommonDistributedMemoryCache();
            //#endregion

            #region Localization

            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    options.SetDefaultCulture("pl-PL");
            //    options.AddSupportedUICultures("pl-PL");
            //    options.FallBackToParentUICultures = true;
            //    options
            //        .RequestCultureProviders
            //        .Remove((IRequestCultureProvider)typeof(AcceptLanguageHeaderRequestCultureProvider));
            //});

            #endregion

            #region Konfiguracja baz danych

            try
            {
                // Kontekst bazy danych PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext
                var portalApiGusApiRegonDataAppSettings = AppSettings.GetInstance();
                services.AddDbContextPool<PortalApiGus.ApiRegon.DataBase.Data.DataBaseContext>(options => options.UseSqlServer(
                    portalApiGusApiRegonDataAppSettings.GetConnectionString(),
                    element => element.EnableRetryOnFailure()
                        .MigrationsHistoryTable("__EFMigrationsHistory", "pagard")));
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }

            try
            {
                // Kontekst bazy danych ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext
                var apiWykazuPodatnikowVatDataAppSettings = ApiWykazuPodatnikowVatData.Models.AppSettings.GetInstance();
                services.AddDbContextPool<ApiWykazuPodatnikowVatDataDbContext>(options => options.UseSqlServer(
                    apiWykazuPodatnikowVatDataAppSettings.GetConnectionString(),
                    element => element.EnableRetryOnFailure().MigrationsHistoryTable("__EFMigrationsHistory", "awpv")));
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }

            try
            {
                // Kontekst bazy danych WebconIntegrationSystem.Data.BPSMainAttDbContext.BPSMainAttDbContext
                var webconIntegrationSystemAppSettings =
                    WebconIntegrationSystem.Models.BPSMainAtt.AppSettings.GetInstance();
                services.AddDbContext<BPSMainAttDbContext>(options =>
                    options.UseSqlServer(webconIntegrationSystemAppSettings.GetConnectionString()));
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }

            try
            {
                // Kontekst bazy danych Vies.Core.Database.Data.ViesCoreDatabaseContext
                var viesCoreDatabaseAppSettings = Vies.Core.Database.Models.AppSettings.GetInstance();
                services.AddDbContextPool<ViesCoreDatabaseContext>(options => options.UseSqlServer(
                    viesCoreDatabaseAppSettings.GetConnectionString(),
                    element => element.EnableRetryOnFailure().MigrationsHistoryTable("__EFMigrationsHistory", "etvc")));
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }

            try
            {
                // Kontekst bazy danych Knf.DataBase.Data.DataBaseContext
                var knfDataBaseModelsAppSettings = new Knf.DataBase.Models.AppSettings();
                services.AddDbContextPool<Knf.DataBase.Data.DataBaseContext>(options => options.UseSqlServer(
                    knfDataBaseModelsAppSettings.GetConnectionString(),
                    element => element.EnableRetryOnFailure().MigrationsHistoryTable("__EFMigrationsHistory", "knf")));
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }

            try
            {
                // Kontekst bazy danych EulerHermes.DataBase.Data.DataBaseContext
                var eulerHermesDataBaseModelsAppSettings = new EulerHermes.DataBase.Models.AppSettings();
                services.AddDbContextPool<EulerHermes.DataBase.Data.DataBaseContext>(options => options.UseSqlServer(
                    eulerHermesDataBaseModelsAppSettings.GetConnectionString(),
                    element => element.EnableRetryOnFailure().MigrationsHistoryTable("__EFMigrationsHistory", "eh")));
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }

            #endregion

            #region Konfiguracja autoryzacja

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
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(EncryptDecrypt.EncryptDecrypt.GetRsaFileContent("id_rsa.ppk.pub")))
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

            #endregion

            #region Add Controllers With Views

            // System sprawdzania poprawności w programie .NET Core 3,0 lub nowszy traktuje parametry niedopuszczające wartości null lub właściwości powiązane tak, jakby miały [Required] atrybut. - Wyłączenie
            services.AddControllersWithViews(options =>
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            #endregion

            #region Add Controllers

            services.AddControllers().AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    options.SerializerSettings.Formatting = Formatting.Indented;
                }
            );

            #endregion

            #region KestrelServerOptions

            // Ważne Konfiguracja Kestrel Server Options !!!
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));

            #endregion

            #region IISServerOption

            // Ważne Konfiguracja IIS Server Options !!!
            services.Configure<IISServerOptions>(Configuration.GetSection("IIS"));

            #endregion

            #region Add Kendo

            services.AddKendo();

            #endregion

            #region HttpContextAccessor

            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            #region Add Mvc Core

            services.AddMvcCore();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region CultureInfo

            CultureInfo[] supportedCultures = {new("pl-PL")};
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pl-PL"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            #endregion

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

            var cookiePolicyOptions = new CookiePolicyOptions {MinimumSameSitePolicy = SameSiteMode.Strict};

            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    "areas",
                    "{area}/{controller}/{action}/{id?}");
                endpoints.MapControllers();
            });

            #region HttpContextAccessor

            // Important Add HttpContextAccessor
            NetAppCommon.HttpContextAccessor.AppContext.Configure(app.ApplicationServices
                .GetRequiredService<IHttpContextAccessor>());

            #endregion

            #region Migracja bazy danych

            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych Knf.DataBase.Data.DataBaseContext
                    EntityContextHelper.RunMigrationAsync<Knf.DataBase.Data.DataBaseContext>(app.ApplicationServices)
                        .Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error(e);
                    if (null != e.InnerException)
                    {
                        _log4Net.Error(e.InnerException);
                    }
                }
            }).Wait();


            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych PortalApiGus.ApiRegon.DataBase.Data.DataBaseContext
                    EntityContextHelper.RunMigrationAsync<PortalApiGus.ApiRegon.DataBase.Data.DataBaseContext>(app.ApplicationServices)
                        .Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error(e);
                    if (null != e.InnerException)
                    {
                        _log4Net.Error(e.InnerException);
                    }
                }
            }).Wait();

            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext
                    EntityContextHelper.RunMigrationAsync<ApiWykazuPodatnikowVatDataDbContext>(app.ApplicationServices)
                        .Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error(e);
                    if (null != e.InnerException)
                    {
                        _log4Net.Error(e.InnerException);
                    }
                }
            }).Wait();

            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych Vies.Core.Database.Data.ViesCoreDatabaseContext
                    EntityContextHelper.RunMigrationAsync<ViesCoreDatabaseContext>(app.ApplicationServices).Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error(e);
                    if (null != e.InnerException)
                    {
                        _log4Net.Error(e.InnerException);
                    }
                }
            }).Wait();

            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych Knf.DataBase.Data.DataBaseContext
                    EntityContextHelper.RunMigrationAsync<Knf.DataBase.Data.DataBaseContext>(app.ApplicationServices).Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error(e);
                    if (null != e.InnerException)
                    {
                        _log4Net.Error(e.InnerException);
                    }
                }
            }).Wait();

            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych EulerHermes.DataBase.Data.DataBaseContext
                    EntityContextHelper.RunMigrationAsync<EulerHermes.DataBase.Data.DataBaseContext>(app.ApplicationServices).Wait();
                }
                catch (Exception e)
                {
                    _log4Net.Error(e);
                    if (null != e.InnerException)
                    {
                        _log4Net.Error(e.InnerException);
                    }
                }
            }).Wait();

            #endregion
        }
    }
}
