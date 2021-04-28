#! bash

cd /d/Praca/NetCoreDev

git submodule deinit .publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevDebug

git rm --cached .publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevDebug

rm -rf .publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevDebug

git commit -m "Removed .publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevDebug submodule"

rm -rf .git/modules/.publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevDebug

git config -f .gitmodules --remove-section submodule..publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevDebug

git config -f .git/config --remove-section submodule..publish/WebApplicationNetCoreDev/WebApplicationNetCoreDevDebug