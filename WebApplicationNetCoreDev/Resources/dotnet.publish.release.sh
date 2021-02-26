#!/bin/bash

PATH=$PATH:"/c/Program Files (x86)/IObit/IObit Unlocker/":"/C/Windows/System32/inetsrv/":"/D/Praca/NetCoreDev/ProgramVersionConsoleApp/bin/Debug/net5.0/"

ProgramVersionConsoleApp.exe "/d/Praca/NetCoreDev/WebApplicationNetCoreDev/WebApplicationNetCoreDev.csproj" "D:\Praca\NetCoreDev\.publish\WebApplicationNetCoreDev\WebApplicationNetCoreDevRelease\Installer\Web.Application.Unimot.Integration.System.aip" "D:\Praca\NetCoreDev\.publish\WebApplicationNetCoreDev\WebApplicationNetCoreDevRelease\Installer\Web.Application.Unimot.Integration.System.Full.Version.aip"

echo "$PWD run dotnet publish"

if [[ ! -z $(tasklist | grep w3wp.exe | awk '{ print $2 }') ]]; then
    for pid in $(tasklist | grep w3wp.exe | awk '{ print $2 }')
    do
        echo "Kill process w3wp.exe $pid"
        taskkill //PID $pid //F
    done
fi

echo "Stop WebApplicationUnimotWork"

appcmd.exe stop site /site.name:WebApplicationUnimotWork

rm -rf "/D/Praca/NetCoreDev/.publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevRelease/wwwroot"

cd /d/Praca/NetCoreDev/WebApplicationNetCoreDev

dotnet clean WebApplicationNetCoreDev.sln -c Release

dotnet publish --no-self-contained -c Release -f net5.0 -o "/D/Praca/NetCoreDev/.publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevRelease/wwwroot" WebApplicationNetCoreDev.csproj

echo "Start WebApplicationUnimotWork"

appcmd.exe start site /site.name:WebApplicationUnimotWork
