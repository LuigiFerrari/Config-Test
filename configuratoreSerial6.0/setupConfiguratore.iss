
#define MyAppName "configuratoreSerial6.0"
#define MyAppVersion "1.0.00"
#define MyAppPublisher "H.A.T."
#define MyAppExeName "configuratoreSerial6.0.exe"
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
OutputBaseFilename=ConfiguratoreSetup_1.0.0
Compression=lzma
SolidCompression=true
AppCopyright=2024 H.A.T.
AppVerName=Configuratore 1.0.0
VersionInfoVersion=1.0.0.00

[Files]
Source: bin\Release\net6.0-windows10.0.22621.0\configuratoreSerial6.0.dll ; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: bin\Release\net6.0-windows10.0.22621.0\configuratoreSerial6.0.exe; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: bin\Release\net6.0-windows10.0.22621.0\configuratoreSerial6.0.runtimeconfig.json; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: bin\Release\net6.0-windows10.0.22621.0\System.IO.Ports.dll; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: bin\Release\net6.0-windows10.0.22621.0\runtimes\win\lib\net6.0\System.IO.Ports.dll; DestDir: {app}; Flags: ignoreversion replacesameversion


[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}