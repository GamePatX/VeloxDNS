
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows;

namespace VeloxDNS_Complete
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (!IsAdministrator())
            {
                RestartAsAdmin();
                Shutdown();
                return;
            }

            SetFolderIcon();
            base.OnStartup(e);
            new MainWindow().Show();
        }

        private bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RestartAsAdmin()
        {
            var exe = Process.GetCurrentProcess().MainModule.FileName;
            var startInfo = new ProcessStartInfo(exe)
            {
                UseShellExecute = true,
                Verb = "runas"
            };
            try
            {
                Process.Start(startInfo);
            }
            catch { }
        }

        private void SetFolderIcon()
        {
            try
            {
                string exeDir = AppContext.BaseDirectory;
                string iconFile = "VeloxDNS.ico";
                string iconPath = Path.Combine(exeDir, iconFile);
                string desktopIniPath = Path.Combine(exeDir, "desktop.ini");

                if (!File.Exists(iconPath))
                    return;

                File.WriteAllText(desktopIniPath,
                    $"[.ShellClassInfo]\r\nIconResource={iconFile},0\r\n");

                File.SetAttributes(desktopIniPath, FileAttributes.Hidden | FileAttributes.System);

                var dirAttr = File.GetAttributes(exeDir);
                if (!dirAttr.HasFlag(FileAttributes.System))
                {
                    File.SetAttributes(exeDir, dirAttr | FileAttributes.System);
                }
            }
            catch { }
        }
    }
}
