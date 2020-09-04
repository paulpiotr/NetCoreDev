#! bash

docker rm -f $(docker ps -a -q)
#docker-compose  -f "C:\Praca\NetCoreDev\WebApplicationNetCoreDev\docker-compose.yml" -p dockercompose-webapplicationnetcoredev --no-ansi config
docker-compose  -f "C:\Praca\NetCoreDev\WebApplicationNetCoreDev\docker-compose.yml" -p webapplicationnetcoredev --no-ansi kill
docker-compose  -f "C:\Praca\NetCoreDev\WebApplicationNetCoreDev\docker-compose.yml" -p webapplicationnetcoredev --no-ansi down --rmi local --remove-orphans
#docker images --filter dangling=true --format {{.ID}}
#docker ps --filter "status=running" --format {{.ID}};{{.Names}}
docker-compose  -f "C:\Praca\NetCoreDev\WebApplicationNetCoreDev\docker-compose.yml" -p webapplicationnetcoredev --no-ansi up -d --build --force-recreate --remove-orphans
