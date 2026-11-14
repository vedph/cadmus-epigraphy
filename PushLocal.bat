@echo off
echo PRESS ANY KEY TO INSTALL TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Epigraphy.Parts\bin\Release\Cadmus.Epigraphy.Parts.10.0.0.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Epigraphy.Parts\bin\Release\Cadmus.Seed.Epigraphy.Parts.10.0.0.nupkg -source C:\Projects\_NuGet
pause
