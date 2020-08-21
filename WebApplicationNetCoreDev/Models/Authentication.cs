using System.ComponentModel.DataAnnotations;

/// <summary>
/// Model klasy autoryzacyjnej
/// </summary>
namespace WebApplicationNetCoreDev.Models
{
    /// <summary>
    /// Model klasy autoryzacyjnej
    /// </summary>
    public class AuthenticationModel
    {
        /// <summary>
        /// Nzawa użytkownika
        /// </summary>
        [Required]
        [Display(Name = "Nazwa użytkownika", Prompt = "Wpisz nazwę użytkownika", Description = "Nazwa użytkownika zarejestrowanego w systemie lub nazwa konta windows.")]
        public string UserName { get; set; }
        /// <summary>
        /// Hasło
        /// </summary>
        [Required]
        [Display(Name = "Hasło", Prompt = "Wpisz hasło", Description = "Hasło użytkownika zarejestrowanego w systemie lub nazwa konta windows.")]
        public string Password { get; set; }
        /// <summary>
        /// Zapamiętaj dane autoryzacyjne w przeglądarce
        /// </summary>
        [Display(Name = "Zapamiętaj Mnie", Prompt = "Zapamiętaj Mnie", Description = "Jeśli zaznaczysz to pole twoje dane autoryzacyjne zostaną zachowane w pmięci przeglądarki.")]
        public bool RememberMe { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
