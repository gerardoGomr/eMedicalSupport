FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Citas.API/Citas.API.csproj", "Citas.API/"]
RUN dotnet restore "Citas.API/Citas.API.csproj"
COPY . .
WORKDIR "/src/Citas.API"
RUN dotnet build "Citas.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Citas.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Citas.API.dll"]