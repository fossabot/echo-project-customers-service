#!/bin/bash
echo "========================================================"
echo "Starting Echo Customers service"

export ASPNETCORE_ENVIRONMENT=local
path=$PWD

echo "Context root:"
if [[ "$path" == *scripts ]]; then
    path=${path/%"/scripts"}
    cd "$path/src/Echo.Customers.API" && pwd
fi

dotnet run