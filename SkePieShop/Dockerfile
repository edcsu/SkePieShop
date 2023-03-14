FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SkePieShop/SkePieShop.csproj", "SkePieShop/"]
RUN dotnet restore "SkePieShop/SkePieShop.csproj"
COPY . .
WORKDIR "/src/SkePieShop"
RUN dotnet build "SkePieShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkePieShop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkePieShop.dll"]
