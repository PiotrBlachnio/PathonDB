FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

ENV STAGE=PRODUCTION

COPY ./PathonDB.Server/PathonDB.Server.csproj /build/PathonDB.Server/
COPY ./PathonDB.DatabaseClient/PathonDB.DatabaseClient.csproj /build/PathonDB.DatabaseClient/

RUN dotnet restore ./build/PathonDB.Server/PathonDB.Server.csproj
RUN dotnet restore ./build/PathonDB.DatabaseClient/PathonDB.DatabaseClient.csproj

COPY . ./build/

WORKDIR /build/

RUN dotnet publish ./PathonDB.Server/PathonDB.Server.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION
RUN dotnet publish ./PathonDB.DatabaseClient/PathonDB.Server.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT [ "dotnet", "PathonDB.Server.dll" ]