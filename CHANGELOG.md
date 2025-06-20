# 🆕 VeloxDNS v1.0.0 – Changelog

## 🇩🇪 Deutsch

### ✨ Neue Funktionen

- **Erweiterte Adapterinformationen**  
  Beim Anzeigen eines einzelnen Netzwerkadapters werden nun folgende Details übersichtlich dargestellt:
  - Adaptername  
  - Status  
  - MAC-Adresse  
  - IPv4-Adresse  
  - IPv6-Adresse  
  - DNS (IPv4 1)  
  - DNS (IPv4 2)  
  - DNS (IPv6 1)  
  - DNS (IPv6 2)

- **DNS-Erreichbarkeitstest**  
  DNS-Server aus den Eingabefeldern können direkt getestet werden. Rückmeldung erfolgt mit Pingzeit oder Fehlerstatus.  
  ⚠ Hinweis: IPv6-DNS-Adressen können unter Umständen als **nicht erreichbar (Timeout)** gemeldet werden, obwohl sie tatsächlich erreichbar sind. Einige Hoster blockieren ICMPv6-Pings aus Sicherheitsgründen – dies ist kein Fehler der App.

### 🛠 Verbesserungen

- **Zuverlässige DNS-Zuweisung**  
  Alle angegebenen DNS-Adressen (primär und sekundär) werden zuverlässig gesetzt.

- **Optimierte Adapterauswahl**  
  Nicht-relevante Adapter (z. B. Loopback, Bluetooth, Tunnel, VMs) werden automatisch ausgeblendet.

- **Modernisierte Benutzeroberfläche**  
  Klare Struktur und überarbeitete Darstellung für bessere Benutzerfreundlichkeit.

---

## 🇬🇧 English

### ✨ New Features

- **Extended Adapter Information**  
  When selecting a single network adapter, the following details are now clearly displayed:
  - Adapter name  
  - Status  
  - MAC address  
  - IPv4 address  
  - IPv6 address  
  - DNS (IPv4 1)  
  - DNS (IPv4 2)  
  - DNS (IPv6 1)  
  - DNS (IPv6 2)

- **DNS Reachability Test**  
  You can now test the DNS servers entered in the input fields. Feedback includes ping time or error message.  
  ⚠ Note: IPv6 DNS servers may occasionally return a **timeout** despite being reachable. This is due to some providers blocking ICMPv6 pings for security reasons – this is not a bug in the application.

### 🛠 Improvements

- **Reliable DNS Assignment**  
  All entered DNS addresses (primary and secondary) are reliably applied.

- **Optimized Adapter Filtering**  
  Irrelevant adapters (e.g., loopback, Bluetooth, tunnels, VMs) are automatically excluded.

- **Modernized User Interface**  
  Clean layout and updated design for improved user experience.

---

# Changelog / Änderungsverlauf

## [v0.2-alpha] – 2025-06-09

### ✨ New Features / Neue Funktionen
- **All physical adapters visible**  
  The adapter list now shows all physical network interfaces, not just the active ones.  
  → Die Adapterliste zeigt jetzt auch inaktive physische Netzwerkadapter an, nicht mehr nur die aktiven.

- **Predefined DNS profiles**  
  Popular and censorship-free DNS services are now included as ready-to-use profiles.  
  → Beliebte und zensurfrei orientierte DNS-Dienste sind als auswählbare Profile direkt verfügbar.

- **Automatic icon assignment on first start**  
  On first launch, the app creates a `desktop.ini` file that sets the VeloxDNS icon for the application folder.  
  → Beim ersten Start erzeugt die App eine `desktop.ini`, die dem Anwendungsordner automatisch das VeloxDNS-Symbol zuweist.

---

## [v0.1-alpha] – Initial Release / Erste Veröffentlichung

- Core functions: set/reset DNS, save/load/delete profiles  
  → Grundfunktionen: DNS setzen, zurücksetzen, Profile speichern/laden/löschen

- UI with tab-based layout for DNS settings and profiles  
  → UI mit TabControl für DNS und Profile

- Admin rights check and automatic elevation if needed  
  → Admin-Rechte-Prüfung und Neustart als Administrator
