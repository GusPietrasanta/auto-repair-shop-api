FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ./auto-repair-shop-api.sln ./
COPY ./Api/Api.csproj ./Api/
COPY ./DataAccessLibrary/DataAccessLibrary.csproj ./DataAccessLibrary/

COPY . .
RUN dotnet restore ./Api/Api.csproj
RUN dotnet publish ./Api/Api.csproj -c Debug -o /app/

# RUN dotnet restore
# COPY . .
# RUN dotnet publish ./Api/Api.csproj -c Release -o /app/


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Api.dll"]