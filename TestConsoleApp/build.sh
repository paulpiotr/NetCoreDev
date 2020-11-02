#!bash

echo $PWD
cd /c/Praca/NetCoreDev/TestConsoleApp
echo "Run dotnet build"
dotnet build "TestConsoleApp.csproj" -c Debug -o bin/Debug/netcoreapp3.1/
echo "Run TestConsoleApp.exe"
./bin/Debug/netcoreapp3.1/TestConsoleApp.exe