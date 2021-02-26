#! bash

function submodulecheck {
    cd $PWD;
    remote_name=$(git remote -v | awk '{ print $1 }');
    remote_url=$(git remote -v | awk '{ print $2 }');
    if [[ $remote_url != *"WebApplicationNetCoreDevDebug"* && $remote_url != *"WebApplicationNetCoreDevRelease"* ]]; then
        if [[ $remote_url == *"http://tfs:8080/tfs"* ]]; then
            git push originisk master
        fi
        if [[ $remote_url == *"https://tfs.isk.com.pl/tfs/ISK"* ]]; then
            git push originisk master
        fi
        if [[ $remote_url == *"https://github.com/paulpiotr"* ]]; then
            git push origin master
        fi
    fi
}
{
    # try
    export -f submodulecheck;
    set -e;
    submodulecheck
    git submodule foreach bash -c 'submodulecheck';

} || {
    # catch
    echo 'Error'
}