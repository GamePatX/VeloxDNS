using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace VeloxDNS_Complete
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, string[]> profiles = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadNetworkAdapters();
            LoadProfiles();
        }

        private void LoadNetworkAdapters()
        {
            AdapterComboBox.Items.Clear();
            AdapterComboBox.Items.Add("Alle Adapter");

            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (IsValidAdapter(nic))
                {
                    AdapterComboBox.Items.Add(nic.Name);
                }
            }

            AdapterComboBox.SelectedIndex = 0;
        }

        private void SetDns_Click(object sender, RoutedEventArgs e)
        {
            string selected = AdapterComboBox.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selected)) return;

            string ipv4dns1 = IPv4Dns1Box.Text.Trim();
            string ipv4dns2 = IPv4Dns2Box.Text.Trim();
            string ipv6dns1 = IPv6Dns1Box.Text.Trim();
            string ipv6dns2 = IPv6Dns2Box.Text.Trim();

            if (selected == "Alle Adapter")
            {
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (IsValidAdapter(nic))
                        DnsConfigurator.SetDns(nic.Name, ipv4dns1, ipv4dns2, ipv6dns1, ipv6dns2);
                }
            }
            else
            {
                DnsConfigurator.SetDns(selected, ipv4dns1, ipv4dns2, ipv6dns1, ipv6dns2);
            }

            MessageBox.Show("DNS gesetzt.", "Erfolg");
        }

        private void SetAuto_Click(object sender, RoutedEventArgs e)
        {
            string selected = AdapterComboBox.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selected)) return;

            if (selected == "Alle Adapter")
            {
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (IsValidAdapter(nic))
                        DnsConfigurator.SetDns(nic.Name, null, null, null, null);
                }
            }
            else
            {
                DnsConfigurator.SetDns(selected, null, null, null, null);
            }

            MessageBox.Show("DNS zurückgesetzt.", "Erfolg");
        }

        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            string name = NewProfileNameBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name)) return;

            profiles[name] = new[]
            {
                IPv4Dns1Box.Text.Trim(),
                IPv4Dns2Box.Text.Trim(),
                IPv6Dns1Box.Text.Trim(),
                IPv6Dns2Box.Text.Trim()
            };

            SaveProfiles();
            LoadProfiles();
            MessageBox.Show("Profil gespeichert.", "Info");
        }

        private void LoadProfile_Click(object sender, RoutedEventArgs e)
        {
            string name = ProfileComboBox.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(name)) return;

            if (profiles.TryGetValue(name, out var dns))
            {
                IPv4Dns1Box.Text = dns[0];
                IPv4Dns2Box.Text = dns[1];
                IPv6Dns1Box.Text = dns[2];
                IPv6Dns2Box.Text = dns[3];
            }
        }

        private void DeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            string name = ProfileComboBox.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(name)) return;

            if (profiles.Remove(name))
            {
                SaveProfiles();
                LoadProfiles();
            }
        }

        private void LoadProfiles()
        {
            ProfileComboBox.Items.Clear();
            profiles.Clear();

            if (File.Exists("profiles.json"))
            {
                var json = File.ReadAllText("profiles.json");
                profiles = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);
            }

            foreach (var name in profiles.Keys)
                ProfileComboBox.Items.Add(name);
        }

        private void SaveProfiles()
        {
            var json = JsonConvert.SerializeObject(profiles, Formatting.Indented);
            File.WriteAllText("profiles.json", json);
        }

        private void ShowAdapterInfo_Click(object sender, RoutedEventArgs e)
        {
            string adapter = AdapterComboBox.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(adapter) || adapter == "Alle Adapter")
            {
                MessageBox.Show("Bitte wählen Sie einen einzelnen Adapter aus, um Informationen anzuzeigen.", "Hinweis");
                return;
            }

            var sb = new StringBuilder();
            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.Name != adapter)
                    continue;

                sb.AppendLine($"Adapter: {nic.Name}");
                sb.AppendLine($"Status: {nic.OperationalStatus}");
                sb.AppendLine($"MAC-Adresse: {BitConverter.ToString(nic.GetPhysicalAddress().GetAddressBytes())}");

                var ipProps = nic.GetIPProperties();

                string ipv4 = "";
                string ipv6 = "";
                foreach (var ip in ipProps.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork && string.IsNullOrEmpty(ipv4))
                        ipv4 = ip.Address.ToString();
                    else if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6 && string.IsNullOrEmpty(ipv6))
                        ipv6 = ip.Address.ToString();
                }

                sb.AppendLine($"IPv4: {ipv4}");
                sb.AppendLine($"IPv6: {ipv6}");

                string dnsV4_1 = "", dnsV4_2 = "", dnsV6_1 = "", dnsV6_2 = "";

                foreach (var dns in ipProps.DnsAddresses)
                {
                    if (dns.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (string.IsNullOrEmpty(dnsV4_1)) dnsV4_1 = dns.ToString();
                        else if (string.IsNullOrEmpty(dnsV4_2)) dnsV4_2 = dns.ToString();
                    }
                    else if (dns.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        if (string.IsNullOrEmpty(dnsV6_1)) dnsV6_1 = dns.ToString();
                        else if (string.IsNullOrEmpty(dnsV6_2)) dnsV6_2 = dns.ToString();
                    }
                }

                sb.AppendLine($"DNS (IPv4 1): {(string.IsNullOrEmpty(dnsV4_1) ? "Keine" : dnsV4_1)}");
                sb.AppendLine($"DNS (IPv4 2): {(string.IsNullOrEmpty(dnsV4_2) ? "Keine" : dnsV4_2)}");
                sb.AppendLine($"DNS (IPv6 1): {(string.IsNullOrEmpty(dnsV6_1) ? "Keine" : dnsV6_1)}");
                sb.AppendLine($"DNS (IPv6 2): {(string.IsNullOrEmpty(dnsV6_2) ? "Keine" : dnsV6_2)}");
            }

            MessageBox.Show(sb.ToString(), "Adapterinfo");
        }

        private void TestDns_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            TestSingleDns(IPv4Dns1Box.Text.Trim(), sb);
            TestSingleDns(IPv4Dns2Box.Text.Trim(), sb);
            TestSingleDns(IPv6Dns1Box.Text.Trim(), sb);
            TestSingleDns(IPv6Dns2Box.Text.Trim(), sb);

            MessageBox.Show(sb.ToString(), "DNS-Test");
        }

        private void TestSingleDns(string address, StringBuilder sb)
        {
            if (string.IsNullOrWhiteSpace(address))
                return;

            try
            {
                using var ping = new Ping();
                var reply = ping.Send(address, 1000);
                if (reply.Status == IPStatus.Success)
                    sb.AppendLine($"{address} erreichbar (Ping: {reply.RoundtripTime} ms)");
                else
                    sb.AppendLine($"{address} nicht erreichbar (Status: {reply.Status})");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"{address} Fehler: {ex.Message}");
            }
        }

        private bool IsValidAdapter(NetworkInterface nic)
        {
            return nic.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                   nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&
                   nic.NetworkInterfaceType != NetworkInterfaceType.Unknown &&
                   nic.NetworkInterfaceType != NetworkInterfaceType.Ppp &&
                   !nic.Description.ToLower().Contains("virtual") &&
                   !nic.Description.ToLower().Contains("pseudo") &&
                   !nic.Description.ToLower().Contains("vmware") &&
                   !nic.Description.ToLower().Contains("bluetooth") &&
                   !nic.Description.ToLower().Contains("loopback");
        }
    }
}
