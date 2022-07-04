#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SmartLiving.Api/SmartLiving.Api.csproj", "SmartLiving.Api/"]
COPY ["SmartLiving.Domain/SmartLiving.Domain.csproj", "SmartLiving.Domain/"]
COPY ["SmartLiving.Library/SmartLiving.Library.csproj", "SmartLiving.Library/"]
COPY ["SmartLiving.Data/SmartLiving.Data.csproj", "SmartLiving.Data/"]
RUN dotnet restore "SmartLiving.Api/SmartLiving.Api.csproj"
COPY . .
WORKDIR "/src/SmartLiving.Api"
RUN dotnet build "SmartLiving.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartLiving.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartLiving.Api.dll"]