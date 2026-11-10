# MeteorModApi

## Running with Docker

The container listens on port `8080`. Replace the values in angle brackets with
your own values:

```sh
docker run --name meteor-mod-api \
  --pull=always \
  --restart=always \
  -p <host-port>:8080 \
  -e ApiKey=<api-key> \
  -e MaxAgeInMinutes=<minutes> \
  -v <data-directory>:/app/data \
  -d ghcr.io/daninator1/meteormodapi:main
```

`ApiKey` is required and must be sent in the `Api-Key` request header.
`MaxAgeInMinutes` is optional and defaults to `10`. The `/app/data` mount
stores synced servers; use a persistent directory on the host.

### Docker Compose

Create `compose.yml`:

```yaml
services:
  meteor-mod-api:
    image: ghcr.io/daninator1/meteormodapi:main
    container_name: meteor-mod-api
    restart: always
    ports:
      - "<host-port>:8080"
    environment:
      ApiKey: "<api-key>"
      MaxAgeInMinutes: "<minutes>"
    volumes:
      - "<data-directory>:/app/data"
```

Start it with:

```sh
docker compose up -d
```

Replace `<host-port>` with the port exposed on the host, `<api-key>` with the
shared API key used by clients, `<minutes>` with the cleanup age, and
`<data-directory>` with a persistent host directory. The `MaxAgeInMinutes`
environment variable and the data volume are optional.

## Authenticating to the GitHub Container Registry

For instructions on authenticating to the GitHub Container Registry, see the
[official guide](https://docs.github.com/en/packages/working-with-a-github-packages-registry#authenticating-to-the-container-registry).
