#region using

using System;
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
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NetAppCommon.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PortalApiGusApiRegonData.Data;
using PortalApiGusApiRegonData.Models;
using StackExchange.Profiling.Storage;
using Vies.Core.Database.Data;
using WebconIntegrationSystem.Data.BPSMainAttDbContext;

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
            #region Konfiguracja baz danych

            try
            {
                // Kontekst bazy danych PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext
                var portalApiGusApiRegonDataAppSettings = AppSettings.GetInstance();
                services.AddDbContext<PortalApiGusApiRegonDataDbContext>(options =>
                    options.UseSqlServer(portalApiGusApiRegonDataAppSettings.GetConnectionString()));
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            try
            {
                // Kontekst bazy danych ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext
                var apiWykazuPodatnikowVatDataAppSettings = ApiWykazuPodatnikowVatData.Models.AppSettings.GetInstance();
                services.AddDbContext<ApiWykazuPodatnikowVatDataDbContext>(options =>
                    options.UseSqlServer(apiWykazuPodatnikowVatDataAppSettings.GetConnectionString()));
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
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
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
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
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
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

            services.AddControllersWithViews(options =>
                // System sprawdzania poprawności w programie .NET Core 3,0 lub nowszy traktuje parametry niedopuszczające wartości null lub właściwości powiązane tak, jakby miały [Required] atrybut. - Wyłączenie
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            // Ważne Konfiguracja Kestrel !!!
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));

            services.AddKendo();

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

            services.AddControllersWithViews().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                }
            );

            services.AddHttpContextAccessor();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvcCore();

            ////typeof(IUIntegrationSystem.Server.RazorClassLibrary.Areas.WorkerService)
            //Assembly assembly = typeof(IUIntegrationSystem.Server.RazorClassLibrary.Areas.WorkerService.Controllers.WorkerServiceController).Assembly;
            ////Assembly assembly = typeof(IUIntegrationSystem.Server.RazorClassLibrary.Areas).Assembly;
            //services.AddControllersWithViews().AddApplicationPart(assembly).AddRazorRuntimeCompilation();

            //services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            //    { options.FileProviders.Add(new EmbeddedFileProvider(assembly)); });

            //var part = new AssemblyPart(assembly);
            //services.AddControllersWithViews()
            //    .ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(part));

            //// Note .AddMiniProfiler() returns a IMiniProfilerBuilder for easy intellisense
            //services.AddMiniProfiler(options =>
            //{
            //    // All of this is optional. You can simply call .AddMiniProfiler() for all defaults

            //    // (Optional) Path to use for profiler URLs, default is /mini-profiler-resources
            //    options.RouteBasePath = "/profiler";

            //    // (Optional) Control storage
            //    // (default is 30 minutes in MemoryCacheStorage)
            //    // Note: MiniProfiler will not work if a SizeLimit is set on MemoryCache!
            //    //   See: https://github.com/MiniProfiler/dotnet/issues/501 for details
            //    ((MemoryCacheStorage) options.Storage).CacheDuration = TimeSpan.FromMinutes(60);

            //    // (Optional) Control which SQL formatter to use, InlineFormatter is the default
            //    options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();

            //    //// (Optional) To control authorization, you can use the Func<HttpRequest, bool> options:
            //    //// (default is everyone can access profilers)
            //    //options.ResultsAuthorize = request => MyGetUserFunction(request).CanSeeMiniProfiler;
            //    //options.ResultsListAuthorize = request => MyGetUserFunction(request).CanSeeMiniProfiler;
            //    //// Or, there are async versions available:
            //    //options.ResultsAuthorizeAsync = async request => (await MyGetUserFunctionAsync(request)).CanSeeMiniProfiler;
            //    //options.ResultsAuthorizeListAsync = async request => (await MyGetUserFunctionAsync(request)).CanSeeMiniProfilerLists;

            //    //// (Optional)  To control which requests are profiled, use the Func<HttpRequest, bool> option:
            //    //// (default is everything should be profiled)
            //    //options.ShouldProfile = request => MyShouldThisBeProfiledFunction(request);

            //    //// (Optional) Profiles are stored under a user ID, function to get it:
            //    //// (default is null, since above methods don't use it by default)
            //    //options.UserIdProvider = request => MyGetUserIdFunction(request);

            //    //// (Optional) Swap out the entire profiler provider, if you want
            //    //// (default handles async and works fine for almost all applications)
            //    //options.ProfilerProvider = new MyProfilerProvider();

            //    // (Optional) You can disable "Connection Open()", "Connection Close()" (and async variant) tracking.
            //    // (defaults to true, and connection opening/closing is tracked)
            //    options.TrackConnectionOpenClose = true;

            //    // (Optional) Use something other than the "light" color scheme.
            //    // (defaults to "light")
            //    options.ColorScheme = StackExchange.Profiling.ColorScheme.Auto;

            //    // The below are newer options, available in .NET Core 3.0 and above:

            //    // (Optional) You can disable MVC filter profiling
            //    // (defaults to true, and filters are profiled)
            //    options.EnableMvcFilterProfiling = true;
            //    // ...or only save filters that take over a certain millisecond duration (including their children)
            //    // (defaults to null, and all filters are profiled)
            //    // options.MvcFilterMinimumSaveMs = 1.0m;

            //    // (Optional) You can disable MVC view profiling
            //    // (defaults to true, and views are profiled)
            //    options.EnableMvcViewProfiling = true;
            //    // ...or only save views that take over a certain millisecond duration (including their children)
            //    // (defaults to null, and all views are profiled)
            //    // options.MvcViewMinimumSaveMs = 1.0m;

            //    // (Optional) listen to any errors that occur within MiniProfiler itself
            //    // options.OnInternalError = e => MyExceptionLogger(e);

            //    // (Optional - not recommended) You can enable a heavy debug mode with stacks and tooltips when using memory storage
            //    // It has a lot of overhead vs. normal profiling and should only be used with that in mind
            //    // (defaults to false, debug/heavy mode is off)
            //    //options.EnableDebugMode = true;
            //});

            //services.AddSwaggerGen(c =>
            //{
            //    c.DocumentFilter<SwaggerHideInDocsFilter>();
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetExecutingAssembly().GetName().Name, Version = "v1" });
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiniProfiler();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                //        $"{Assembly.GetExecutingAssembly().GetName().Name} v1");
                //});
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

            //app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();

            // Important Add HttpContextAccessor
            NetAppCommon.HttpContextAccessor.AppContext.Configure(app.ApplicationServices
                .GetRequiredService<IHttpContextAccessor>());

            #region Migracja bazy danych

            Task.Run(() =>
            {
                try
                {
                    // Migracja bazy danych PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext
                    EntityContextHelper.RunMigrationAsync<PortalApiGusApiRegonDataDbContext>(app.ApplicationServices)
                        .Wait();
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
                    EntityContextHelper.RunMigrationAsync<ApiWykazuPodatnikowVatDataDbContext>(app.ApplicationServices)
                        .Wait();
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
                    EntityContextHelper.RunMigrationAsync<ViesCoreDatabaseContext>(app.ApplicationServices).Wait();
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
