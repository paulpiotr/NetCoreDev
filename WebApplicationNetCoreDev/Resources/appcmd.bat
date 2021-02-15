@ECHO off

SET PATH=%PATH%;"C:\Windows\System32\inetsrv\"

ECHO Restart ISS server Web.Application.Unimot.Integration.System Application.

appcmd.exe stop site /site.name:Web.Application.Unimot.Integration.System

appcmd.exe start site /site.name:Web.Application.Unimot.Integration.System

EXIT