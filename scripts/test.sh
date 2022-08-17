#!/bin/bash
echo "========================================================"
echo "Runing Tests for Echo Customers service"

path=$PWD

echo "Context root:"
if [[ "$path" == *scripts ]]; then
    path=${path/%"/scripts"}
    cd "$path" && pwd
fi

dotnet test