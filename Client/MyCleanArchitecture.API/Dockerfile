#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Client/MyCleanArchitecture.API/MyCleanArchitecture.API.csproj", "Client/MyCleanArchitecture.API/"]
RUN dotnet restore "Client/MyCleanArchitecture.API/MyCleanArchitecture.API.csproj"
COPY . .
WORKDIR "/src/Client/MyCleanArchitecture.API"
RUN dotnet build "MyCleanArchitecture.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCleanArchitecture.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCleanArchitecture.API.dll"]