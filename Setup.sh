#!/bin/bash

set -e

until /root/.dotnet/tools/dotnet-ef database update --no-build; do
	>&2 echo "SQL serving is starting up"
done

>&2 echo "SQL server is up --executing command"

/root/.dotnet/tools/dotnet-ef database update