#!/bin/bash

find ${pwd} -type f | grep .csproj$ | grep -v Base | xargs -i -t -n1 dotnet run -p {} $1
