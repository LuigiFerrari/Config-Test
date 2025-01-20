
#define MyAppName "Config&Test"
#define MyAppVersion "1.7.00"
#define MyAppPublisher "H.A.T."
#define MyAppExeName "Config&Test.exe"
#define DefaultGroup "\Roccheggiani\Config&Test"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{8761E405-0A24-4B8D-9427-FF64EEAD04C7}
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
OutputBaseFilename=Config&TestSetup_1.7.0
Compression=lzma
SolidCompression=true
AppCopyright=2024 H.A.T.
AppVerName=Config and Test 1.7.0
VersionInfoVersion=1.7.0.00

[Files]
Source: bin\Release\net6.0-windows10.0.22621.0\Config&Test.dll ; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: bin\Release\net6.0-windows10.0.22621.0\Config&Test.exe; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: bin\Release\net6.0-windows10.0.22621.0\Config&Test.runtimeconfig.json; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: bin\Release\net6.0-windows10.0.22621.0\System.IO.Ports.dll; DestDir: {app}; Flags: ignoreversion replacesameversion
Source: bin\Release\net6.0-windows10.0.22621.0\runtimes\win\lib\net6.0\System.IO.Ports.dll; DestDir: {app}; Flags: ignoreversion replacesameversion


[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}