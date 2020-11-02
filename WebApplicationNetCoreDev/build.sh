# !bash

echo $PWD
echo "Run dotnet build"
echo "Kill process"
taskkill //f //pid $(tasklist | grep w3wp.exe | awk '{ print $2 }')
echo "Stop WebApplicationUnimotDebug"
/C/Windows/System32/inetsrv/appcmd.exe stop site /site.name:WebApplicationUnimotDebug
cd /c/Praca/NetCoreDev/WebApplicationNetCoreDev
dotnet build "WebApplicationNetCoreDev.csproj" -c Debug -o bin/Debug/netcoreapp3.1/
echo "Start WebApplicationUnimotDebug"
/C/Windows/System32/inetsrv/appcmd.exe start site /site.name:WebApplicationUnimotDebug
