FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IkeaShop.Order/IkeaShop.Order.csproj", "IkeaShop.Order/"]
RUN dotnet restore "IkeaShop.Order/IkeaShop.Order.csproj"
COPY . .
WORKDIR "/src/IkeaShop.Order"
RUN dotnet build "IkeaShop.Order.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IkeaShop.Order.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IkeaShop.Order.dll"]
