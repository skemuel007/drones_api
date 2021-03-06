#!/bin/sh

set -e
run_cmd="dotnet run --server.urls http://*:80"


until /root/.dotnet/tools/dotnet-ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd
/root/.dotnet/tools/dotnet-ef database update