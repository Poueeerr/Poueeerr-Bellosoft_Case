# Project Overview

## Bellosoft Test Case
The system fetches distinct news articles from an external API based on a keyword and language, persisting the data in the database.
It also provides routes to query the database for stored news, and includes a user registration and login system with JWT authentication.

## Requisitos
- Docker & Docker Compose installed
- API KEY from https://gnews.io
- .NET and PostgreSQL do NOT need to be installed locally, Docker handles that.
  
## Create a .env file in the project root
```bash
# PostgreSQL connection string
ConnectionStrings__DefaultConnection=Host=db;Port=5432;Database=bellosoft;Username=postgres;Password=2005

ApiSettings__ApiKey=YOUR_APIKEY

JWT_KEY=SECURE_LONG_KEY
JWT_ISSUER=MySystem
JWT_AUDIENCE=MySystemUsers
JWT_EXPIRES=60
```
Make sure to use a JWT key with at least 32 characters to avoid IDX10720 errors.

## Running the project with Docker

Make sure Docker Desktop is running.

Build and start the containers:
```bash
  docker compose up --build
```

This will build the API image and start two containers:

api-dotnet → the .NET 8 API

postgres-db → the PostgreSQL database

## Access the API:

Swagger UI: http://localhost:5000/swagger/index.html

API endpoints: use the URLs from Swagger

The API container listens on port 8080 internally, mapped to port 5000 on your host.

## Notes

The API environment is set to Development inside Docker to enable Swagger.

PostgreSQL data is persisted in a Docker volume (postgres_data), so database contents survive container restarts.

All secrets (JWT key, API key, DB credentials) are loaded from .env.

## Third-party API documentation link
https://docs.gnews.io

.gitignore must contain:
.env
