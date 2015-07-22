@echo off
pushd %~dp0

: Update Version.txt file
PowerShell "$versionFile = Get-Content -Path version.txt ; $version = [version]($versionFile) ; $newVersion = New-Object -TypeName System.Version -ArgumentList $version.Major, $version.Minor, $version.Build, ($version.Revision + 1) ; $newVersion | Set-Content -Path version.txt"

: Grab version from text file
set /p VERSION_ASSEMBLY=<version.txt

: Build everything, passing the version number
"C:\Program Files (x86)\MSBuild\14.0\Bin\amd64\MSBuild.exe" /t:Rebuild /p:Configuration=Release;VersionAssembly=%VERSION_ASSEMBLY%

popd

