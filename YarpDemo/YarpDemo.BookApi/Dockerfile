FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["YarpDemo.BookApi/YarpDemo.BookApi.csproj", "YarpDemo.BookApi/"]
RUN dotnet restore "YarpDemo.BookApi/YarpDemo.BookApi.csproj"
COPY . .
WORKDIR "/src/YarpDemo.BookApi"
RUN dotnet build "YarpDemo.BookApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "YarpDemo.BookApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YarpDemo.BookApi.dll"]
