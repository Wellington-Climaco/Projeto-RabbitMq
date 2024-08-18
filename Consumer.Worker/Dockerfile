FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5025

ENV ASPNETCORE_URLS=http://+:5025

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Consumer.Worker/Consumer.Worker.csproj", "Consumer.Worker/"]
RUN dotnet restore "Consumer.Worker/Consumer.Worker.csproj"
COPY . .
WORKDIR "/src/Consumer.Worker"
RUN dotnet build "Consumer.Worker.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Consumer.Worker.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consumer.Worker.dll"]
