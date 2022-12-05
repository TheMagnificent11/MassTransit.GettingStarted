#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MassTransit.GettingStarted.Worker/MassTransit.GettingStarted.Worker.csproj", "MassTransit.GettingStarted.Worker/"]
COPY ["MassTransit.GettingStarted.Contracts/MassTransit.GettingStarted.Contracts.csproj", "MassTransit.GettingStarted.Contracts/"]
RUN dotnet restore "MassTransit.GettingStarted.Worker/MassTransit.GettingStarted.Worker.csproj"
COPY . .
WORKDIR "/src/MassTransit.GettingStarted.Worker"
RUN dotnet build "MassTransit.GettingStarted.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MassTransit.GettingStarted.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MassTransit.GettingStarted.Worker.dll"]