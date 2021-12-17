#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5004

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MIW-CustomerAuthService.Api/MIW-CustomerAuthService.Api.csproj", "MIW-CustomerAuthService.Api/"]
RUN dotnet restore "MIW-CustomerAuthService.Api/MIW-CustomerAuthService.Api.csproj"
COPY . .
WORKDIR "/src/MIW-CustomerAuthService.Api"
RUN dotnet build "MIW-CustomerAuthService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MIW-CustomerAuthService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MIW-CustomerAuthService.Api.dll"]