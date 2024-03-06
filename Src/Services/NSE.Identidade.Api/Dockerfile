FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Services/NSE.Identidade.Api/NSE.Identidade.Api.csproj", "Src/Services/NSE.Identidade.Api/"]
RUN dotnet restore "Src/Services/NSE.Identidade.Api/NSE.Identidade.Api.csproj"
COPY . .
WORKDIR "/src/Src/Services/NSE.Identidade.Api"
RUN dotnet build "NSE.Identidade.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NSE.Identidade.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Identidade.Api.dll"]
