FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /app 

COPY *.sln .
COPY PathonDB.Server/*.csproj ./PathonDB.Server/
COPY PathonDB.DatabaseClient/*.csproj ./PathonDB.DatabaseClient/

RUN dotnet restore 

COPY PathonDB.Server/. ./PathonDB.Server/
COPY PathonDB.DatabaseClient/. ./PathonDB.DatabaseClient/

WORKDIR /app/PathonDB.Server
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime
WORKDIR /app 

COPY --from=build /app/PathonDB.Server/out ./
ENTRYPOINT ["dotnet", "PathonDB.Server.dll"]