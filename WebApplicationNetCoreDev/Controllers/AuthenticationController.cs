using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleImpersonation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationNetCoreDev.Models;

namespace WebApplicationNetCoreDev.Controllers
{
    /// <summary>
    /// Kontroler akcji autoryzacji
    /// </summary>
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class AuthenticationController : Controller
    {
        /// <summary>
        /// Log4net Logger
        /// </summary>
        private static readonly log4net.ILog Log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Wyświetl formularz autoryzacji.
        /// GET: /Authentication
        /// </summary>
        /// <returns>IActionResult</returns>
        [AllowAnonymous]
        // GET: /Authentication
        public IActionResult Index([FromQuery] string returnUrl)
        {
            try
            {
                return User.Identity.IsAuthenticated
                    ? Url.IsLocalUrl(returnUrl)
                        ? Redirect(returnUrl)
                        : (IActionResult)RedirectToAction(nameof(Index), "Home", new { UserName = User.Identity.Name, returnUrl })
                    : View();
            }
            catch (Exception e)
            {
                Log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound(e);
            }
        }

        /// <summary>
        /// To protect from overposting attacks, enable the specific properties you want to bind to, for more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// Wykonaj akcję autoryzacji i przełącz do udanej próbie na stronę lub wyświetl formularz autoryzacji.
        /// POST: /Authentication
        /// </summary>
        /// <param name="model">object model AS WebApplicationNetCoreDev.Models.AuthenticationModel</param>
        /// <param name="returnUrl"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        // POST: /Authentication
        public async Task<IActionResult> IndexAsync([Bind("UserName, Password, RememberMe")] AuthenticationModel model, [FromQuery] string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var result = false;
                        result = await WindowsIdentityCookieAuthenticationAsync(model);
                        if (true == result)
                        {
                            return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : (IActionResult)RedirectToAction(nameof(Index), "Home", new { model.UserName, returnUrl });
                        }

                        result = await HttpContextAuthenticateWindowsCookieAuthenticationAsync(model);
                        if (true == result)
                        {
                            return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : (IActionResult)RedirectToAction(nameof(Index), "Home", new
                            {
                                model.UserName,
                                returnUrl
                            });
                        }
                        //return Challenge("Windows");
                    }
                    catch (Exception e)
                    {
                        Log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                        model.Message = e.Message;
                        model.StackTrace = e.StackTrace;
                        return View(model);
                    }
                }
                return View(model);
            }
            catch (Exception e)
            {
                Log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound(e);
            }
        }

        /// <summary>
        /// Wykonaj akcję wylogowania
        /// GET: Authentication/Logout
        /// </summary>
        /// <returns>IActionResult</returns>
        [Authorize]
        // GET: Authentication/Logout
        public async Task<IActionResult> LogoutAsync()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception e)
            {
                Log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound(e);
            }
        }

        /// <summary>
        /// Wyświetl stronę brak uprawnień
        /// GET: Authentication/AccessDenied
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        // GET: Authentication/AccessDenied
        public IActionResult AccessDenied([FromQuery] string returnUrl)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound(e);
            }
        }

        /// <summary>
        /// Wyświetl profil użytkownika
        /// GET: Authentication/UserProfile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Cookies")]
        // GET: Authentication/UserProfile
        public IActionResult UserProfile()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound(e);
            }
        }

        /// <summary>
        /// Generuj token autoryzacji Jwt - wyświetl formularz
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Cookies")]
        // GET: Authentication/GenerateJwtToken
        public IActionResult GenerateJwtToken()
        {
            try
            {
                var jwtTokenModel = new JwtTokenModel(HttpContext);
                return View(jwtTokenModel);
            }
            catch (Exception e)
            {
                Log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound(e);
            }
        }

        /// <summary>
        /// Generuj token autoryzacji Jwt - zapisz formularz
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = "Cookies")]
        // Post Authentication/GenerateJwtToken
        public IActionResult GenerateJwtToken([Bind("UserName, Key, Expires")] JwtTokenModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model = model.GenerateJwtToken();
                    NetAppCommon.Configuration.SetAppSettingValue<string>("JwtTokenUserName", model.UserName);
                    NetAppCommon.Configuration.SetAppSettingValue<string>("JwtStringToken", model.JwtStringToken);
                }
                return View(model);
            }
            catch (Exception e)
            {
                Log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound(e);
            }
        }

        /// <summary>
        /// Uwierzytelnianie Windows Identity Cookie Authentication - autoryzacja danymi windows, zapis danych do ciasteczka
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Task<bool> result Authentication</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<bool> WindowsIdentityCookieAuthenticationAsync([Bind("UserName, Password, RememberMe")] AuthenticationModel model)
        {
            try
            {
                var userCredentials = new UserCredentials(model.UserName, model.Password);
                return await Impersonation.RunAsUser(userCredentials, LogonType.Batch, async () =>
                {
                    using (var windowsIdentity = WindowsIdentity.GetCurrent())
                    {
                        AppDomain appDomain = Thread.GetDomain();
                        appDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                        var windowsPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, windowsIdentity.Name),
                            new Claim("FullName", windowsIdentity.Name)
                        };
                        foreach (WindowsBuiltInRoles windowsBuiltInRoles in WindowsBuiltInRoles.WindowsBuiltInRolesList())
                        {
                            if (windowsPrincipal.IsInRole(windowsBuiltInRoles.WindowsBuiltInRole))
                            {
                                claims.Add(new Claim(ClaimTypes.Role, windowsBuiltInRoles.RoleNeme));
                            }
                        }
                        foreach (IdentityReference group in windowsIdentity.Groups)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, group.Translate(typeof(NTAccount)).ToString()));
                        }
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authenticationProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            // Refreshing the authentication session should be allowed.
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                            // The time at which the authentication ticket expires. A 
                            // value set here overrides the ExpireTimeSpan option of 
                            // CookieAuthenticationOptions set with AddCookie.
                            IsPersistent = true,
                            // Whether the authentication session is persisted across 
                            // multiple requests. When used with cookies, controls
                            // whether the cookie's lifetime is absolute (matching the
                            // lifetime of the authentication ticket) or session-based.
                            //IssuedUtc = <DateTimeOffset>,
                            // The time at which the authentication ticket was issued.
                            RedirectUri = "/",
                            // The full path or absolute URI to be used as an http 
                            // redirect response value.
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties);
                    }
                    return true;
                });
            }
            catch (Exception e)
            {
                model.Message = e.Message;
                model.StackTrace = e.StackTrace;
                return false;
            }
        }

        /// <summary>
        /// Uwierzytelnianie Windows Identity Cookie Authentication - autoryzacja standardowa danymi windows, zapis danych do ciasteczka
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<bool> HttpContextAuthenticateWindowsCookieAuthenticationAsync([Bind("UserName, Password, RememberMe")] AuthenticationModel model)
        {
            try
            {
                AuthenticateResult result = await HttpContext.AuthenticateAsync("Windows");
                if (result?.Principal is WindowsPrincipal windowsPrincipal)
                {
                    //// we will issue the external cookie and then redirect the
                    //// user back to the external callback, in essence, treating windows
                    //// auth the same as any other external authentication mechanism
                    //AuthenticationProperties authenticationProperties = new AuthenticationProperties() { RedirectUri = Url.Action("Index", "Home"), Items = { { "returnUrl", Url.Action("Index", "Home") }, { "scheme", "Windows" }, } };
                    //ClaimsIdentity claimsIdentity = new ClaimsIdentity("Windows");
                    //// the sid is a good sub value
                    //claimsIdentity.AddClaim(new Claim(JwtClaimTypes.Subject, windowsPrincipal.FindFirst(ClaimTypes.PrimarySid).Value));
                    //// the account name is the closest we have to a display name
                    //claimsIdentity.AddClaim(new Claim(JwtClaimTypes.Name, windowsPrincipal.Identity.Name));
                    //// add the groups as claims -- be careful if the number of groups is too large

                    var windowsIdentity = windowsPrincipal.Identity as WindowsIdentity;
                    AppDomain appDomain = Thread.GetDomain();
                    appDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

                    //WindowsPrincipal windowsPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;

                    var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, windowsIdentity.Name),
                            new Claim("FullName", windowsIdentity.Name)
                        };
                    foreach (WindowsBuiltInRoles windowsBuiltInRoles in WindowsBuiltInRoles.WindowsBuiltInRolesList())
                    {
                        if (windowsPrincipal.IsInRole(windowsBuiltInRoles.WindowsBuiltInRole))
                        {
                            claims.Add(new Claim(ClaimTypes.Role, windowsBuiltInRoles.RoleNeme));
                        }
                    }
                    foreach (IdentityReference group in windowsIdentity.Groups)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, group.Translate(typeof(NTAccount)).ToString()));
                    }
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authenticationProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        // Refreshing the authentication session should be allowed.
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.
                        IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.
                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.
                        RedirectUri = "/"
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties);
                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                model.Message = e.Message;
                model.StackTrace = e.StackTrace;
                return false;
            }
        }
    }
}
