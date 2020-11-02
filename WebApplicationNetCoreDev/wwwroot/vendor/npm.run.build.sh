#!/bin/bash
rm -rf dist/*
npm install --no-optional
npm audit fix
npm run build
npm audit fix