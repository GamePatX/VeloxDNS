using System.Diagnostics;
using System.Windows;

namespace VeloxDNS_Complete
{
    public static class DnsConfigurator
    {
        public static void SetDns(string adapter, string ipv4dns1, string ipv4dns2, string ipv6dns1, string ipv6dns2)
        {
            void Execute(string args)
            {
                var psi = new ProcessStartInfo("netsh", args)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var proc = Process.Start(psi);
                proc.WaitForExit();

                var error = proc.StandardError.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(error))
                {
                    MessageBox.Show(
                        $"Fehler beim Ausführen des Befehls:\nnetsh {args}\n\n{error}",
                        "DNS-Konfiguration",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );
                }
            }

            // IPv4
            if (!string.IsNullOrWhiteSpace(ipv4dns1))
            {
                Execute($"interface ipv4 set dnsservers name=\"{adapter}\" static {ipv4dns1} primary");
                if (!string.IsNullOrWhiteSpace(ipv4dns2))
                    Execute($"interface ipv4 add dnsservers name=\"{adapter}\" address={ipv4dns2} index=2");
            }
            else
            {
                Execute($"interface ipv4 set dnsservers name=\"{adapter}\" source=dhcp");
            }

            // IPv6
            if (!string.IsNullOrWhiteSpace(ipv6dns1))
            {
                Execute($"interface ipv6 set dnsservers name=\"{adapter}\" static {ipv6dns1} primary");
                if (!string.IsNullOrWhiteSpace(ipv6dns2))
                    Execute($"interface ipv6 add dnsservers name=\"{adapter}\" address={ipv6dns2} index=2");
            }
            else
            {
                Execute($"interface ipv6 set dnsservers name=\"{adapter}\" source=dhcp");
            }
        }
    }
}
