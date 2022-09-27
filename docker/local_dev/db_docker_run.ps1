docker-compose -f "db-docker-compose.yml" stop
docker-compose -f "db-docker-compose.yml" rm --force
docker-compose -f "db-docker-compose.yml" up --build db
