@echo off
setlocal

set /p project=Podaj nazwe projektu: 

dotnet new console -o ./%project%
dotnet sln AlgorithmsAndDataStructures.sln add ./%project%/%project%.csproj