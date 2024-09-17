# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MuleWebAPIPhatpt19/MuleWebAPIPhatpt19.csproj", "MuleWebAPIPhatpt19/"]
RUN dotnet restore "MuleWebAPIPhatpt19/MuleWebAPIPhatpt19.csproj"
COPY . .
WORKDIR "/src/MuleWebAPIPhatpt19"
RUN dotnet build "MuleWebAPIPhatpt19.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "MuleWebAPIPhatpt19.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: running the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MuleWebAPIPhatpt19.dll"]
