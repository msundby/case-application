# Device Management Test Case API

Instructions for running the project locally.

Requirements:
- .NET 8 SDK
- Docker
- Git
- EF Core CLI (for database migrations)

Clone the repository:</br>
`git clone <repository-url>`</br>
`cd case-application`

Build the project</br>
`dotnet build`

Start PostgreSQL using Docker:</br>
`docker run -d --name devicemanagement-db -e POSTGRES_DB=devicemanagement -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 postgres:16`

Run the API locally:
`dotnet run --project case-application\case-application.csproj`

The API will be available at:</br>
`http://localhost:5105/swagger`

Notes: I have included the connection string in **appsettings.Development** in this repository to simplify local testing. In real environments this kind of data would be handled through environment variables or a secret manager.
