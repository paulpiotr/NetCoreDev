using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleImpersonation;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationNetCoreDev.Models;

/// <summary>
/// Kontroler akcji autoryzacji
/// </summary>
namespace WebApplicationNetCoreDev.Controllers
{
    /// <summary>
    /// Kontroler akcji autoryzacji
    /// </summary>
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        // GET: /Authentication
        /// <summary>
        /// Index - formularz autoryzacji GET: Authentication
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction(nameof(Index), "Home", new { Username = User.Identity.Name, ReturnUrl = returnUrl });
            }
            return View();
        }
        // POST: /Authentication
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Index - akcje autoryzacji Post :Authentication
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> IndexAsync([Bind("Username, Password, RememberMe")] WebApplicationNetCoreDev.Models.AuthenticationModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    bool result = false;
                    result = await WindowsIdentityCookieAuthenticationAsync(model);
                    if (true == result)
                    {
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction(nameof(Index), "Home", new { model.Username });
                    }
                    result = await HttpContextAuthenticateWindowsCookieAuthenticationAsync(model);
                    if (true == result)
                    {
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction(nameof(Index), "Home", new { model.Username });
                    }
                    //return Challenge("Windows");
                }
                catch (Exception e)
                {
                    model.Message = e.Message;
                    model.StackTrace = e.StackTrace;
                    return View(model);
                }
            }
            return View(model);
        }
        // GET: /Authentication
        /// <summary>
        /// Index - formularz autoryzacji GET: Authentication
        /// </summary>
        /// <returns></returns>
        [Authorize]
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
                return RedirectToAction(nameof(Index), "Home", new { Message = e.Message });
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
        public async Task<bool> WindowsIdentityCookieAuthenticationAsync([Bind("Username, Password, RememberMe")] Models.AuthenticationModel model)
        {
            try
            {
                UserCredentials userCredentials = new UserCredentials(model.Username, model.Password);
                return await Impersonation.RunAsUser(userCredentials, LogonType.Interactive, async () =>
                {
                    WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                    AppDomain appDomain = Thread.GetDomain();
                    appDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                    WindowsPrincipal windowsPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
                    List<Claim> claims = new List<Claim>() {
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
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties authenticationProperties = new AuthenticationProperties
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
        public async Task<bool> HttpContextAuthenticateWindowsCookieAuthenticationAsync([Bind("Username, Password, RememberMe")] Models.AuthenticationModel model)
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

                    WindowsIdentity windowsIdentity = windowsPrincipal.Identity as WindowsIdentity;
                    AppDomain appDomain = Thread.GetDomain();
                    appDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

                    //WindowsPrincipal windowsPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;

                    List<Claim> claims = new List<Claim>() {
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
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties authenticationProperties = new AuthenticationProperties
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