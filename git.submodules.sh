#! bash

git submodule sync --recursive &&
git submodule init &&
git submodule update &&
git submodule foreach git checkout master &&
git submodule foreach git pull origin master