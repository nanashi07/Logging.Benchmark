find /home/nanashi07/RiderProjects/Loggin.Benchmark -type f | grep .csproj$ | grep -v Base | xargs -t -n1 dotnet run -p
