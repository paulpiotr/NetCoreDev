#! bash

docker rm -f $(docker ps -a -q)
docker-compose -f "C:\Praca\NetCoreDev\WebApplicationNetCoreDev\docker-compose.yml" -p webapplicationnetcoredev --no-ansi kill
docker-compose -f "C:\Praca\NetCoreDev\WebApplicationNetCoreDev\docker-compose.yml" -p webapplicationnetcoredev --no-ansi down --rmi local --remove-orphans
docker-compose -f "C:\Praca\NetCoreDev\WebApplicationNetCoreDev\docker-compose.yml" -p webapplicationnetcoredev --no-ansi up -d --build --force-recreate --remove-orphans
