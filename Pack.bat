@echo off
echo BUILD Cadmus Epigraphy Packages
del .\Cadmus.Epigraphy.Parts\bin\Release\*.snupkg
del .\Cadmus.Epigraphy.Parts\bin\Release\*.nupkg

del .\Cadmus.Seed.Epigraphy.Parts\bin\Release\*.snupkg
del .\Cadmus.Seed.Epigraphy.Parts\bin\Release\*.nupkg

cd .\Cadmus.Epigraphy.Parts
dotnet pack -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.Epigraphy.Parts
dotnet pack -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
