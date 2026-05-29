FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY AFurAffair.sln .
COPY AFurAffair.Web/AFurAffair.Web.csproj AFurAffair.Web/
RUN dotnet restore
COPY . .
RUN dotnet publish AFurAffair.Web/AFurAffair.Web.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "AFurAffair.Web.dll"]
