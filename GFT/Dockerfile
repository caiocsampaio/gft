#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GFT/GFT.csproj", "GFT/"]
COPY ["Facades/GFT.Facades.csproj", "Facades/"]
COPY ["GFT.Models/GFT.Models.csproj", "GFT.Models/"]
RUN dotnet restore "GFT/GFT.csproj"
COPY . .
WORKDIR "/src/GFT"
RUN dotnet build "GFT.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GFT.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GFT.dll"]