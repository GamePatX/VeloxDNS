   M S B A M L   `   `   `  ����   VeloxDNS_Complete"    VeloxDNS_Complete.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  VeloxDNS – Modern UI��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=����#f3f3f3$��Segoe UI)�.��� $��20q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��VeloxDNS��$��26(�$
��Bold"����#333� $��1��$��0,20,0,0q� � ColumnDefinitions �� $��2* ��� $��* �.+��� $��0��$��0 0 20 0q�.+��� $��Network adapter��$
��Bold"�$��14(��� -    ��Name$ AdapterComboBox��$��0,5,0,15q�$��30���� $��IPv4 DNS��$
��Bold"��� -    ��Name$ IPv4Dns1Box��$��0,5,0,5q�$��28���� -   $ IPv4Dns2Box��$��0,0,0,15q�$��28���� $��IPv6 DNS��$
��Bold"��� -   $ IPv6Dns1Box��$��0,5,0,5q�$��28���� -   $ IPv6Dns2Box��$��0,0,0,15q�$��28����  �� Orientation$ 
Horizontal=�$��0,10,0,0q�.+��� -   $��DNS set��$	��120��$��0,0,10,0q�$��30���� -   $��Rewind��$	��120��$��30���� -   $��DNS test��$	��120��$��30��$��0,10,0,0q��� $��1��.+��� $��profile��$
��Bold"�$��14(��� -	   $ ProfileComboBox��$��0,5,0,10q�$��30���� $ 
Horizontal=�.+��� -
   $
��load��$��80��$��0,0,5,0q�$��28���� -   $��Delete��$��80��$��28���� -   $ NewProfileNameBox��$��0,10,0,5q�$��28���� -   $
��Save��$	��120��$��30���� $��	0,20,0,10q��� -   $��Show adapter information��$	��200��$��30��