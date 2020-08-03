#!/bin/bash
rm -rf /c/Praca/Inergis/XLServiceRest/XLServiceWeb/wwwroot/vendor/dist/*
npm install --no-optional
npm audit fix
#npm-upgrade
npm-upgrade
#npm run build
npm run build
npm audit fix