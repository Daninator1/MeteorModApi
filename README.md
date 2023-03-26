# MeteorModApi

To run:

`docker run --name meteor-mod-api -p PORT:80/tcp -e ApiKey=API_KEY --restart=always -d daninator1/meteor-mod-api`

Optionally override max age in seconds for cleanup:

`docker run --name meteor-mod-api -p PORT:80/tcp -e ApiKey=API_KEY -e MaxAgeInSeconds=SECONDS --restart=always -d daninator1/meteor-mod-api`
