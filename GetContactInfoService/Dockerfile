FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GetContactInfoService/GetContactInfoService.csproj", "GetContactInfoService/"]
RUN dotnet restore "GetContactInfoService/GetContactInfoService.csproj"
COPY . .
WORKDIR "/src/GetContactInfoService"
RUN dotnet build "GetContactInfoService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GetContactInfoService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GetContactInfoService.dll"]
