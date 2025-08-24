# Project Overview

## Bellosoft Test Case
The system fetches distinct news articles from an external API based on a keyword and language, persisting the data in the database.
It also provides routes to query the database for stored news, and includes a user registration and login system with JWT authentication.

## Requisitos
- .NET 8.0 installed
- PostgreSQL installed and running (default port 5432)
- API KEY from https://gnews.io
  
## Create a .env file in the project root
```bash
# PostgreSQL connection string
ConnectionStrings__DefaultConnection=Host=localhost;Port=5432;Database=bellosoft;Username=postgres;Password=2005

ApiSettings__ApiKey=YOUR_APIKEY

JWT_KEY=SECURE_LONG_KEY
JWT_ISSUER=MySystem
JWT_AUDIENCE=MySystemUsers
JWT_EXPIRES=60
```
Make sure to use a JWT key with at least 32 characters to avoid IDX10720 errors.

## Running the project

Run ```dotnet restore``` to install dependencies.

Run ```dotnet run``` to start the application.

## Third-party API documentation link
https://docs.gnews.io

.gitignore must contain:
.env
