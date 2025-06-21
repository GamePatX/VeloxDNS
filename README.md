# VeloxDNS

**VeloxDNS** ist ein portables Windows-Tool zur schnellen und komfortablen Änderung von DNS-Servern. Es unterstützt sowohl IPv4- als auch IPv6-Adressen und bietet eine moderne, intuitive Benutzeroberfläche – ganz ohne Installation.

**VeloxDNS** is a portable Windows tool that allows users to quickly and easily change DNS server settings. It supports both IPv4 and IPv6, and features a modern, intuitive user interface – no installation required.

---

## 🧩 Funktionen / Features

### 🇩🇪 Deutsch
- DNS-Server für **alle physischen Netzwerkadapter** oder gezielt einen auswählen
- Unterstützung für **IPv4** und **IPv6**
- **Vorgefertigte DNS-Profile** (z. B. Google, Cloudflare, AdGuard) enthalten
- **Eigene Profile speichern, laden und löschen**
- **Adapterinformationen anzeigen** (inkl. IP, MAC, DNS-Adressen)
- **Erweiterter DNS-Test** zur Überprüfung der Erreichbarkeit
- ⚠ Hinweis: IPv6-DNS-Adressen können unter Umständen als **nicht erreichbar (Timeout)** gemeldet werden, obwohl sie tatsächlich erreichbar sind. Einige Hoster blockieren ICMPv6-Pings aus Sicherheitsgründen – dies ist kein Fehler der App.
- **Icon-Integration**: Beim ersten Start wird eine `desktop.ini` erstellt, die das Ordnersymbol automatisch anpasst
- **Portabel** – keine Installation erforderlich
- Startet automatisch mit Administratorrechten

### 🇬🇧 English
- Set DNS servers for **all physical network adapters** or select one individually
- Supports **IPv4** and **IPv6**
- Includes **predefined DNS profiles** (e.g. Google, Cloudflare, AdGuard)
- Save, load and delete **custom DNS profiles**
- **View adapter information** (IP, MAC, DNS addresses)
- **Extended DNS test** to check reachability
- ⚠ Note: IPv6 DNS servers may occasionally return a **timeout** despite being reachable. This is due to some providers blocking ICMPv6 pings for security reasons – this is not a bug in the application.
- **Icon integration**: On first start, a `desktop.ini` is created to apply a custom folder icon
- **Portable** – no installation required
- Automatically runs with administrative privileges

---

## 💻 Kompatibilität / Compatibility

### 🇩🇪 Deutsch  
Dieses Tool wurde speziell für **Windows 10 und 11** entwickelt.  
Andere Windows-Versionen sind nicht offiziell getestet.

### 🇬🇧 English  
This tool was developed specifically for **Windows 10 and 11**.  
Other Windows versions are not officially tested.

---

## 📘 Anwendung / How to Use

### 🇩🇪 Deutsch

1. Adapter auswählen (oder „Alle Adapter“ wählen)
2. DNS-Adressen (IPv4 / IPv6) eingeben
3. Auf **„Setzen“** klicken, um die DNS-Einstellungen zu übernehmen
4. Zum Zurücksetzen auf DHCP: **„Automatisch“** klicken
5. Unter dem Tab **„Eigene Profile“** können DNS-Kombinationen gespeichert, geladen und gelöscht werden

### 🇬🇧 English

1. Select an adapter (or choose "All Adapters")
2. Enter DNS addresses (IPv4 / IPv6)
3. Click **“Set”** to apply the settings
4. Click **“rewind”** to reset DNS to DHCP
5. Under the **"profile"** tab, save, load and delete your own DNS setups

---

## 📥 Download

➡ [Download the latest version here](https://github.com/GamePatX/VeloxDNS/releases)

---

## 🪪 Lizenz / License

Dieses Projekt steht unter der **MIT-Lizenz**.  
This project is licensed under the **MIT License**.

---

## 📦 Verwendete Drittanbieter-Bibliotheken / Third-Party Libraries

### 🇩🇪 Deutsch  
Dieses Projekt verwendet quelloffene Bibliotheken von Drittanbietern, die unter ihren jeweiligen Lizenzen stehen.  
Bitte beachte, dass jede dieser Bibliotheken ihren eigenen Lizenzbedingungen unterliegt.  

### 🇬🇧 English  
This project uses open-source third-party libraries, each subject to its own license.  
Please note that each library retains its respective licensing terms.

---

### 📘 [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

- **Autor / Author**: James Newton-King  
- **Lizenz / License**: [MIT License](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md)  

- **🇩🇪 Beschreibung**:  
  Bibliothek zum Serialisieren und Deserialisieren von JSON-Daten in .NET-Projekten.

- **🇬🇧 Description**:  
  Library for serializing and deserializing JSON data in .NET projects.

---

### 🎨 WPF User Interface (Standard Microsoft WPF)

- **Autor / Author**: Microsoft  
- **Lizenz / License**: Teil des .NET Frameworks – [Lizenzinformationen](https://licenses.nuget.org/MIT)  

- **🇩🇪 Beschreibung**:  
  Die Benutzeroberfläche basiert vollständig auf dem offiziellen WPF-Framework von Microsoft.  
  Es wurden keine externen UI-Bibliotheken wie MahApps oder MaterialDesign verwendet.

- **🇬🇧 Description**:  
  The user interface is built entirely on Microsoft’s official WPF framework.  
  No external UI libraries such as MahApps or MaterialDesign have been used.

---

## ⚖️ Lizenzhinweis / License Notice

### 🇩🇪 Deutsch  
Dieses Projekt steht unter der **MIT-Lizenz** (siehe [LICENSE.md](./LICENSE.md)).  
Alle eingebundenen Drittanbieter-Komponenten behalten ihre jeweiligen Urheberrechte und Lizenzbedingungen.  
Die jeweilige Lizenz gilt **nur für die entsprechende Komponente**, nicht für das gesamte Projekt.

### 🇬🇧 English  
This project is licensed under the **MIT License** (see [LICENSE.md](./LICENSE.md)).  
All third-party libraries used retain their respective copyrights and licensing terms.  
Each license applies **only to its respective component**, not the entire project.


---

## ❓ FAQ – Häufig gestellte Fragen

### 🇩🇪 Deutsch

**🔒 Ist das Programm sicher?**  
Ja. VeloxDNS verwendet ausschließlich Standardfunktionen von Windows (.NET/WMI), ohne tief ins System einzugreifen.

**🌐 Wird das Internet oder DNS aktiv beeinflusst?**  
Nein. Das Tool legt nur fest, welcher DNS-Server verwendet wird. Die Geschwindigkeit und Zensurfreiheit hängen vom gewählten Anbieter ab.

**📁 Werden Daten gespeichert oder übertragen?**  
Nein. Es erfolgt keine Internetverbindung. Nur lokale DNS-Profile werden gespeichert.

**👤 Wer steckt hinter dem Projekt?**  
Entwickelt von GamePatX in Zusammenarbeit mit ChatGPT. Es handelt sich um ein nicht-kommerzielles Open-Source-Projekt.

---

### 🇬🇧 English

**🔒 Is the program safe?**  
Yes. VeloxDNS uses only standard Windows functions (.NET/WMI) and does not interfere with critical system areas.

**🌐 Does it affect internet or DNS behavior?**  
No. It only sets which DNS server to use. Speed and censorship depend on the provider selected.

**📁 Does it store or send any data?**  
No. There’s no internet communication. Only local DNS profiles are saved in the app folder.

**👤 Who made this?**  
Developed by GamePatX in cooperation with ChatGPT as a non-commercial open source project.
