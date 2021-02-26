#!/bin/bash

echo "$PWD Run dotnet build"

if [[ ! -z $(tasklist | grep w3wp.exe | awk '{ print $2 }') ]]; then
    for pid in $(tasklist | grep w3wp.exe | awk '{ print $2 }')
    do
        echo "Kill process w3wp.exe $pid"
        taskkill //PID $pid //F
    done
fi

echo "Stop WebApplicationUnimotWork"
/C/Windows/System32/inetsrv/appcmd.exe stop site /site.name:WebApplicationUnimotWork

cd /d/Praca/NetCoreDev/WebApplicationNetCoreDev

echo "dotnet clean WebApplicationNetCoreDev.sln -c Release"
dotnet clean WebApplicationNetCoreDev.sln -c Release

echo "dotnet dev-certs https --trust"
dotnet dev-certs https --trust

echo "dotnet run -p WebApplicationNetCoreDev.csproj -c Release -f net5.0"
dotnet run -p WebApplicationNetCoreDev.csproj -c Release -f net5.0

echo "Start WebApplicationUnimotWork"
/C/Windows/System32/inetsrv/appcmd.exe start site /site.name:WebApplicationUnimotWork
