; VideoCodec — Windows "Uygulamalar" listesinde gorunen kurulum paketi
; 1) Once EXE yayinla:
;    dotnet publish ..\VideoCodec.csproj -c Release -r win-x64 --self-contained true ^
;      -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true ^
;      -o ..\publish\win-x64-single
; 2) Inno Setup indir: https://jrsoftware.org/isdl.php
; 3) Inno'da File > Open ile bu dosyayi ac, Build > Compile (veya ISCC VideoCodec.iss)

#define MyAppName "VideoCodec"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "VideoCodec"
#define MyAppExeName "VideoCodec.exe"
; Sabit GUID: guncelleme / yeniden kurulum icin degistirmeyin
#define MyAppId "{{E4B8C9D2-7F1A-4E3B-9C5D-2A8E6F1B4D0C}}"

[Setup]
AppId={#MyAppId}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=.\output
OutputBaseFilename=VideoCodec-Setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64
PrivilegesRequired=admin
UninstallDisplayIcon={app}\{#MyAppExeName}

[Languages]
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\publish\win-x64-single\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
