#!/bin/bash
echo "========================================================"
echo "Building Echo Customers service"
path=$PWD

echo "Context root:"
if [[ "$path" == *scripts ]]; then
    path=${path/%"/scripts"}
    cd "$path" && pwd
fi
echo "========================================================"
echo "Pulling latest changes from origin"
git branch | grep '^\*' | awk '{printf "Current branch: " "\033[32m" $2 "\033[0m" "\n"}'
git pull

dotnet build -c release

echo "Finish"
echo "========================================================"