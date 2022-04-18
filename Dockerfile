FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /app
COPY . .
RUN dotnet publish ./OrderService/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:5000"

ENTRYPOINT [ "dotnet", "OrderService.dll"]