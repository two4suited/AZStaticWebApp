FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StaticWebApp.Web/StaticWebApp.Web.csproj", "StaticWebApp.Web/"]
RUN dotnet restore "StaticWebApp.Web/StaticWebApp.Web.csproj"
COPY . .
WORKDIR "/src/StaticWebApp.Web"
RUN dotnet build "StaticWebApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StaticWebApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StaticWebApp.Web.dll"]
