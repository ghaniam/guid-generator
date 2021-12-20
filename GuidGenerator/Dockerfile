#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore "GuidGenerator.Web/GuidGenerator.Web.csproj"

WORKDIR /src/.

COPY . .
RUN dotnet build "GuidGenerator.Web/GuidGenerator.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GuidGenerator.Web/GuidGenerator.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuidGenerator.Web.dll"]