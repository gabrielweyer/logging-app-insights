FROM microsoft/dotnet:2.1.302-sdk-alpine3.7 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and publish
COPY . ./
RUN dotnet publish -c Release -o /out

# Build runtime image
FROM microsoft/dotnet:2.1.2-aspnetcore-runtime-alpine3.7
RUN mkdir -p /tmp/app-logs
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "Logging.Web.dll"]
