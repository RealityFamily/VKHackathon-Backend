FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

COPY VKHackathon.sln .
COPY VKHackathon.WebApp/*.csproj ./VKHackathon.WebApp/
COPY Models/*.csproj ./Models/
RUN dotnet restore

COPY VKHackathon.WebApp/. ./VKHackathon.WebApp/
COPY Models/. ./Models/
WORKDIR /app/VKHackathon.WebApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/VKHackathon.WebApp/out ./
ENTRYPOINT ["dotnet", "VKHackathon.WebApp.dll"]

