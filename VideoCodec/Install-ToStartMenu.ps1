#Requires -Version 5.1
# VideoCodec.exe'yi kullanici klasorune kurar ve Baslat menusune "VideoCodec" kisayolu ekler.
# Windows aramada "VideoCodec" yazinca cikmasi icin bu kisayol yeterlidir.
# Calistirma: sag tik -> PowerShell ile calistir, veya: powershell -ExecutionPolicy Bypass -File .\Install-ToStartMenu.ps1

$ErrorActionPreference = 'Stop'

$exeName = 'VideoCodec.exe'

# Oncelik: yaninda duran exe, sonra yayin klasoru
$candidates = @(
    (Join-Path $PSScriptRoot $exeName)
    (Join-Path $PSScriptRoot "publish\win-x64-single\$exeName")
    (Join-Path $PSScriptRoot "bin\Release\net8.0-windows\win-x64\$exeName")
)

$sourceExe = $candidates | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $sourceExe) {
    Write-Error "Kaynak bulunamadi. Bu script'i VideoCodec proje klasorunde calistirin veya once 'dotnet publish' ile EXE olusturun. Aranan: $exeName"
}

$installRoot = Join-Path $env:LOCALAPPDATA 'Programs\VideoCodec'
$targetExe = Join-Path $installRoot $exeName

New-Item -ItemType Directory -Force -Path $installRoot | Out-Null
Copy-Item -LiteralPath $sourceExe -Destination $targetExe -Force

$programs = [Environment]::GetFolderPath('Programs')
$shortcutPath = Join-Path $programs 'VideoCodec.lnk'

$shell = New-Object -ComObject WScript.Shell
$sc = $shell.CreateShortcut($shortcutPath)
$sc.TargetPath = $targetExe
$sc.WorkingDirectory = $installRoot
$sc.Description = 'VideoCodec'
$sc.Save()

[System.Runtime.InteropServices.Marshal]::ReleaseComObject($sc) | Out-Null
[System.Runtime.InteropServices.Marshal]::ReleaseComObject($shell) | Out-Null

Write-Host "Tamam."
Write-Host "  Kurulum: $installRoot"
Write-Host "  Kisayol: $shortcutPath"
Write-Host "Baslat'ta veya Windows aramada 'VideoCodec' yazarak acabilirsiniz (indeks gecikmesi birkac dakika surebilir)."
