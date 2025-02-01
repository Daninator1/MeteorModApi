# MeteorModApi

## Running the Container

To start the MeteorModApi container, use the following command:

```sh
docker run --name meteor-mod-api \
  --pull=always \
  -p PORT:80/tcp \
  -e ApiKey=API_KEY \
  --restart=always \
  -v /path/to/data:/app/data \
  -d ghcr.io/daninator1/meteormodapi:main
```

### Environment Variables
- `ApiKey` (required): API key for authentication.
- `MaxAgeInSeconds` (optional): Override the default maximum age (in seconds) for cleanup.

### Persisting Synced Servers
To persist synced servers, mount a volume to `/app/data`:

```sh
-v /path/to/data:/app/data
```
Replace `/path/to/data` with your desired persistent storage location.

### Example with Max Age Override
```sh
docker run --name meteor-mod-api \
  --pull=always \
  -p PORT:80/tcp \
  -e ApiKey=API_KEY \
  -e MaxAgeInSeconds=SECONDS \
  --restart=always \
  -v /path/to/data:/app/data \
  -d ghcr.io/daninator1/meteormodapi:main
```

## Notes
- Replace `PORT` with the port number you want to expose.
- Replace `API_KEY` with your actual API key.
- Replace `SECONDS` with the desired max age for cleanup.
- Replace `/path/to/data` with a persistent directory on your host machine.

## Authenticating to the GitHub Container Registry

For instructions on how to authenticate to the GitHub Container Registry, please refer to the [official guide](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-container-registry#authenticating-to-the-container-registry).