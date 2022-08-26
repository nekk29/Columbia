#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Company.Product.Module.Apis/Company.Product.Module.Apis.csproj", "Company.Product.Module.Apis/"]
RUN dotnet restore "Company.Product.Module.Apis/Company.Product.Module.Apis.csproj"
COPY . .
WORKDIR "/src/Company.Product.Module.Apis"
RUN dotnet build "Company.Product.Module.Apis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company.Product.Module.Apis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.Product.Module.Apis.dll"]