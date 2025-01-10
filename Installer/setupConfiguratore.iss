
#define MyAppName "configuratoreSerial"
#define MyAppVersion "1.0.00"
#define MyAppPublisher "H.A.T."
#define MyAppExeName "configuratoreSerial.exe"
#define DefaultGroup "\Roccheggiani\Configuratore"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E1D60195-DDC8-4C38-8FE7-DE9EDEA8D838}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL=
AppSupportURL=
AppUpdatesURL=
DefaultDirName={commonpf}{#DefaultGroup}
DefaultGroupName={#DefaultGroup}
OutputDir=.
OutputBaseFilename=ConfiguratoreInstaller_1.0.0
Compression=lzma
SolidCompression=true
AppCopyright=2024 H.A.T.
AppVerName=Configuratore
VersionInfoVersion=1.0.0.00

[Files]
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\configuratoreSerial.dll ; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\configuratoreSerial.exe; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\configuratoreSerial.runtimeconfig.json; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\configuratoreSerial.deps.json; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\System.IO.Ports.dll; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\System.Management.dll; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\WinRT.Runtime.dll; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\Microsoft.Windows.SDK.NET.dll; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\runtimes\win\lib\net7.0\*; DestDir: {app}\runtimes\win\lib\net7.0; Flags: ignoreversion replacesameversion
Source: ..\configuratoreSerial6.0\bin\Release\net8.0-windows10.0.22621.0\runtimes\win\lib\net8.0\*; DestDir: {app}\runtimes\win\lib\net8.0; Flags: ignoreversion replacesameversion


[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}