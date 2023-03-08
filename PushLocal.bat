@echo off
echo PRESS ANY KEY TO INSTALL TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Epigraphy.Parts\bin\Debug\Cadmus.Epigraphy.Parts.1.0.1.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Epigraphy.Parts\bin\Debug\Cadmus.Seed.Epigraphy.Parts.1.0.1.nupkg -source C:\Projects\_NuGet
pause
