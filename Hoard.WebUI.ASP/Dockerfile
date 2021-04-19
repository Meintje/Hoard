#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hoard.WebUI.ASP/Hoard.WebUI.ASP.csproj", "Hoard.WebUI.ASP/"]
COPY ["Hoard.WebUI.Services/Hoard.WebUI.Services.csproj", "Hoard.WebUI.Services/"]
COPY ["Hoard.Core.Interfaces/Hoard.Core.Interfaces.csproj", "Hoard.Core.Interfaces/"]
COPY ["Hoard.Core.Entities/Hoard.Core.Entities.csproj", "Hoard.Core.Entities/"]
COPY ["Hoard.Data.Persistence/Hoard.Infrastructure.Persistence.csproj", "Hoard.Data.Persistence/"]
COPY ["Hoard.Core.Constants/Hoard.Core.Constants.csproj", "Hoard.Core.Constants/"]
RUN dotnet restore "Hoard.WebUI.ASP/Hoard.WebUI.ASP.csproj"
COPY . .
WORKDIR "/src/Hoard.WebUI.ASP"
RUN dotnet build "Hoard.WebUI.ASP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hoard.WebUI.ASP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hoard.WebUI.ASP.dll"]