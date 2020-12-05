
echo $PWD
echo "Run dotnet build"
echo "Kill process"
taskkill //PID $(tasklist | grep w3wp.exe | awk '{ print $2 }') //F
echo "Stop WebApplicationUnimotWork"
/C/Windows/System32/inetsrv/appcmd.exe stop site /site.name:WebApplicationUnimotWork
cd /d/Praca/NetCoreDev/WebApplicationNetCoreDev
dotnet build "WebApplicationNetCoreDev.csproj" -c Debug -o bin/Debug/net5.0/
echo "Start WebApplicationUnimotWork"
/C/Windows/System32/inetsrv/appcmd.exe start site /site.name:WebApplicationUnimotWork
