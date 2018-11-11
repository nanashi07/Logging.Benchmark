find ${pwd} -type f | grep .csproj$ | grep -v Base | xargs -t -n1 dotnet run -p
