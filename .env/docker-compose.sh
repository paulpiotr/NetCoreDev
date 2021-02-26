#! bash

docker rm -f $(docker ps -a -q)
docker-compose -p webapplicationnetcoredev --no-ansi kill
docker-compose -p webapplicationnetcoredev --no-ansi down --rmi local --remove-orphans
docker-compose -p webapplicationnetcoredev --no-ansi up -d --build --force-recreate --remove-orphans