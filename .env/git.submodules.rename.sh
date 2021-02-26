#! bash

function submodulecheck {
    cd $PWD;
    fetch="https://github.com/paulpiotr/$(basename $PWD).git";
    push="git@github.com:paulpiotr/$(basename $PWD).git";
    remote_name=$(git remote -v | awk '{ print $1 }');
    remote_url=$(git remote -v | awk '{ print $2 }');
    if [[ $remote_name == *"originisk"* ]]; then
        echo "Test originisk It's there!";
    else
        echo "Test originisk No";
    fi
    if [[ $remote_name == "origin" ]]; then
        echo "Test origin YES";
    else
        if [[ $remote_url == *"http://tfs:8080/tfs"* ]]; then
            echo "Test origin NO, Test http://tfs:8080/tfs YES";
            git remote add origin $fetch
            git remote set-url --push origin $push
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