FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Web/NSE.WebApp.Mvc/NSE.WebApp.Mvc.csproj", "Src/Web/NSE.WebApp.Mvc/"]
RUN dotnet restore "Src/Web/NSE.WebApp.Mvc/NSE.WebApp.Mvc.csproj"
COPY . .
WORKDIR "/src/Src/Web/NSE.WebApp.Mvc"
RUN dotnet build "NSE.WebApp.Mvc.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NSE.WebApp.Mvc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.WebApp.Mvc.dll"]
