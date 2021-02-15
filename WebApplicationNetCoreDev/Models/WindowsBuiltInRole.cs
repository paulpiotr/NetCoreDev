#region using

using System.Collections.Generic;
using System.Security.Principal;

#endregion

namespace WebApplicationNetCoreDev.Models
{
    public class WindowsBuiltInRoles
    {
        public WindowsBuiltInRole WindowsBuiltInRole { get; private set; }
        public int RoleId { get; private set; }
        public string RoleNeme { get; private set; }
        public string RoleDescription { get; private set; }
        public string Text { get; private set; }
        public string Value { get; private set; }

        public static List<WindowsBuiltInRoles> WindowsBuiltInRolesList() =>
            new()
            {
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.AccountOperator,
                    RoleId = 548,
                    RoleNeme = "AccountOperator",
                    RoleDescription =
                        "Operatorzy kont zarządzają kontami użytkowników na komputerze lub w domenie.",
                    Text = "Operatorzy kont zarządzają kontami użytkowników na komputerze lub w domenie.",
                    Value = "AccountOperator"
                },
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.Administrator,
                    RoleId = 544,
                    RoleNeme = "Administrator",
                    RoleDescription =
                        "Administratorzy mają pełny i nieograniczony dostęp do komputera lub domeny.",
                    Text = "Administratorzy mają pełny i nieograniczony dostęp do komputera lub domeny.",
                    Value = "AccountOperator"
                },
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.BackupOperator,
                    RoleId = 551,
                    RoleNeme = "BackupOperator",
                    RoleDescription =
                        "Operatorzy kopii zapasowych mogą przesłonić ograniczenia zabezpieczeń wyłącznie w celu tworzenia kopii zapasowych lub przywracania plików.",
                    Text =
                        "Operatorzy kopii zapasowych mogą przesłonić ograniczenia zabezpieczeń wyłącznie w celu tworzenia kopii zapasowych lub przywracania plików.",
                    Value = "BackupOperator"
                },
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.Guest,
                    RoleId = 546,
                    RoleNeme = "Guest",
                    RoleDescription = "Goście są bardziej ograniczeni od użytkowników.",
                    Text = "Goście są bardziej ograniczeni od użytkowników.",
                    Value = "Guest"
                },
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.PowerUser,
                    RoleId = 547,
                    RoleNeme = "PowerUser",
                    RoleDescription =
                        "Użytkownicy zaawansowani mają większość uprawnień administracyjnych z pewnymi ograniczeniami. W ten sposób Użytkownicy zaawansowani mogą uruchamiać starsze aplikacje oprócz certyfikowanych aplikacji.",
                    Text =
                        "Użytkownicy zaawansowani mają większość uprawnień administracyjnych z pewnymi ograniczeniami. W ten sposób Użytkownicy zaawansowani mogą uruchamiać starsze aplikacje oprócz certyfikowanych aplikacji.",
                    Value = "PowerUser"
                },
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.PrintOperator,
                    RoleId = 550,
                    RoleNeme = "PrintOperator",
                    RoleDescription = "Operatorzy drukowania mogą przejąć kontrolę nad drukarką.",
                    Text = "Operatorzy drukowania mogą przejąć kontrolę nad drukarką.",
                    Value = "PrintOperator"
                },
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.Replicator,
                    RoleId = 552,
                    RoleNeme = "Replicator",
                    RoleDescription = "Replikatory obsługują replikację plików w domenie.",
                    Text = "Replikatory obsługują replikację plików w domenie.",
                    Value = "Replicator"
                },
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.SystemOperator,
                    RoleId = 549,
                    RoleNeme = "SystemOperator",
                    RoleDescription = "Operatorzy systemu zarządzają określonym komputerem.",
                    Text = "Operatorzy systemu zarządzają określonym komputerem.",
                    Value = "SystemOperator"
                },
                new WindowsBuiltInRoles
                {
                    WindowsBuiltInRole = WindowsBuiltInRole.User,
                    RoleId = 545,
                    RoleNeme = "User",
                    RoleDescription =
                        "Użytkownicy nie mogą wprowadzać przypadkowych lub zamierzonych zmian w całym systemie. W ten sposób użytkownicy mogą uruchamiać certyfikowane aplikacje, ale nie starsze aplikacje.",
                    Text =
                        "Użytkownicy nie mogą wprowadzać przypadkowych lub zamierzonych zmian w całym systemie. W ten sposób użytkownicy mogą uruchamiać certyfikowane aplikacje, ale nie starsze aplikacje.",
                    Value = "User"
                }
            };
    }
}
