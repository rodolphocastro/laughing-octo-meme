FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Todoer.Api/Todoer.Api.csproj", "Todoer.Api/"]
RUN dotnet restore "Todoer.Api/Todoer.Api.csproj"
COPY . .
WORKDIR "/src/Todoer.Api"
RUN dotnet build "Todoer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todoer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todoer.Api.dll"]
