#!/bin/bash

echo "$PWD kill"

if [[ ! -z $(tasklist | grep w3wp.exe | awk '{ print $2 }') ]]; then
    for pid in $(tasklist | grep w3wp.exe | awk '{ print $2 }')
    do
        echo "Kill process w3wp.exe $pid"
        taskkill //PID $pid //F
    done
fi

if [[ ! -z $(tasklist | grep dotnet.exe | awk '{ print $2 }') ]]; then
    for pid in $(tasklist | grep dotnet.exe | awk '{ print $2 }')
    do
        echo "Kill process dotnet.exe $pid"
        taskkill //PID $pid //F
    done
fi
