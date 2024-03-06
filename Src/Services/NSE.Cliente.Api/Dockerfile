FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Services/NSE.Cliente.Api/NSE.Cliente.Api.csproj", "Src/Services/NSE.Cliente.Api/"]
RUN dotnet restore "Src/Services/NSE.Cliente.Api/NSE.Cliente.Api.csproj"
COPY . .
WORKDIR "/src/Src/Services/NSE.Cliente.Api"
RUN dotnet build "NSE.Cliente.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NSE.Cliente.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Cliente.Api.dll"]
