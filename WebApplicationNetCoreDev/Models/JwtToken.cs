﻿#region using

using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using NetAppCommon;

#endregion

namespace WebApplicationNetCoreDev.Models
{
    /// <summary>
    ///     Klasa modelu Jwt Token
    /// </summary>
    public class JwtTokenModel
    {
        /// <summary>
        ///     Log4net Logger
        /// </summary>
        private readonly ILog log4net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        /// <summary>
        ///     Konstruktor bez parametrów
        /// </summary>
        public JwtTokenModel() { }

        /// <summary>
        ///     Konstruktor z paramentrem HttpContext
        /// </summary>
        /// <param name="httpContext">httpContext AS HttpContext</param>
        public JwtTokenModel(HttpContext httpContext)
        {
            try
            {
                UserName = httpContext.User.Identity.Name;
                Key = EncryptDecrypt.EncryptDecrypt.GetRsaFileContent("id_rsa.ppk.pub");
                Expires = 1 * 60 * 60 * 24 * 366 * 10;
                JwtStringToken = Configuration.GetValue<string>("JwtStringToken");
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
        }

        /// <summary>
        ///     Nzawa użytkownika
        /// </summary>
        [Required]
        [Display(Name = "Nazwa użytkownika", Prompt = "Wpisz nazwę użytkownika",
            Description = "Nazwa użytkownika zarejestrowanego w systemie lub nazwa konta windows.")]
        public string UserName { get; set; }

        /// <summary>
        ///     Klucz szyfrujący
        /// </summary>
        [Required]
        [Display(Name = "Klucz szyfrujący", Prompt = "Wpisz klucz szyfrujący",
            Description =
                "Klucz szyfrujący TOKEN. Domyślnie plik id_rsa.ppk. W celu wygenerowania poprawnego klucza użyj ssh-keygen i zapisz plik jako id_rsa.ppk w lokalizacji głównej projektu.")]
        public string Key { get; set; }

        /// <summary>
        ///     Czas ważności TOKENU
        /// </summary>
        [Required]
        [Display(Name = "Czas ważności TOKENU", Prompt = "Wpisz czas ważności TOKENU",
            Description = "Czas ważności TOKENU wyrażony w sekundach po którym TOKEN traci ważność.")]
        public int Expires { get; set; }

        /// <summary>
        ///     Klucz Jwt Token
        /// </summary>
        [Display(Name = "Jwt String Token", Prompt = "Jwt String Token",
            Description = "Klucz Jwt Token utworzony przez algorytm.")]
        public string JwtStringToken { get; private set; }

        /// <summary>
        ///     Klucz Jwt Token
        /// </summary>
        [Display(Name = "SecurityToken Token", Prompt = "SecurityToken Token",
            Description = "Objekt klucza SecurityToken utworzony przez algorytm.")]
        public SecurityToken JwtSecurityToken { get; private set; }

        /// <summary>
        ///     Utwórz token autoryzacji
        /// </summary>
        /// <returns>JwtTokenModel</returns>
        public JwtTokenModel GenerateJwtToken()
        {
            try
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(Key);
                var securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {new Claim("UserName", UserName)}),
                    Expires = DateTime.UtcNow.AddSeconds(Expires),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                JwtSecurityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                JwtStringToken = jwtSecurityTokenHandler.WriteToken(JwtSecurityToken);
                return this;
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return null;
            }
        }
    }
}
