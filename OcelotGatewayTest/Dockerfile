FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OcelotGatewayTest/OcelotGatewayTest.csproj", "OcelotGatewayTest/"]
RUN dotnet restore "OcelotGatewayTest/OcelotGatewayTest.csproj"
COPY . .
WORKDIR "/src/OcelotGatewayTest"
RUN dotnet build "OcelotGatewayTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotGatewayTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotGatewayTest.dll"]
