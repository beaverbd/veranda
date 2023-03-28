#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Veranda.Service.User.Api/Veranda.Service.User.Api.csproj", "Veranda.Service.User.Api/"]
COPY ["Veranda.Common/Veranda.Common.csproj", "Veranda.Common/"]
RUN dotnet restore "Veranda.Service.User.Api/Veranda.Service.User.Api.csproj"
COPY . .
WORKDIR "/src/Veranda.Service.User.Api"
RUN dotnet build "Veranda.Service.User.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Veranda.Service.User.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Veranda.Service.User.Api.dll"]