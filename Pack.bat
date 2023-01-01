@echo off
echo BUILD Cadmus Epigraphy Packages
del .\Cadmus.Epigraphy.Parts\bin\Debug\*.snupkg
del .\Cadmus.Epigraphy.Parts\bin\Debug\*.nupkg

del .\Cadmus.Seed.Epigraphy.Parts\bin\Debug\*.snupkg
del .\Cadmus.Seed.Epigraphy.Parts\bin\Debug\*.nupkg

cd .\Cadmus.Epigraphy.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.Epigraphy.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
