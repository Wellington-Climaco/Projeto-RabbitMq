FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5025

ENV ASPNETCORE_URLS=http://+:5025

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Publisher/ProducerAPI.csproj", "Publisher/"]
RUN dotnet restore "Publisher/ProducerAPI.csproj"
COPY . .
WORKDIR "/src/Publisher"
RUN dotnet build "ProducerAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ProducerAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProducerAPI.dll"]
