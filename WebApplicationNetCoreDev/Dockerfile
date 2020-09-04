#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebApplicationNetCoreDev/WebApplicationNetCoreDev.csproj", "WebApplicationNetCoreDev/"]
COPY ["PortalApiGus/ApiRegon/PortalApiGusApiRegonData/PortalApiGusApiRegonData.csproj", "PortalApiGus/ApiRegon/PortalApiGusApiRegonData/"]
COPY ["EncryptDecrypt/EncryptDecrypt/EncryptDecrypt.csproj", "EncryptDecrypt/EncryptDecrypt/"]
COPY ["Log4netLogger/Log4netLogger.csproj", "Log4netLogger/"]
COPY ["SimpleImpersonation/src/SimpleImpersonation.csproj", "SimpleImpersonation/src/"]
RUN dotnet restore "WebApplicationNetCoreDev/WebApplicationNetCoreDev.csproj"
COPY . .
WORKDIR "/src/WebApplicationNetCoreDev"
RUN dotnet build "WebApplicationNetCoreDev.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplicationNetCoreDev.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplicationNetCoreDev.dll"]