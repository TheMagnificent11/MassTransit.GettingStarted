#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MassTransit.GettingStarted.Consumer/MassTransit.GettingStarted.Consumer.csproj", "MassTransit.GettingStarted.Consumer/"]
COPY ["MassTransit.GettingStarted.Contracts/MassTransit.GettingStarted.Contracts.csproj", "MassTransit.GettingStarted.Contracts/"]
RUN dotnet restore "MassTransit.GettingStarted.Consumer/MassTransit.GettingStarted.Consumer.csproj"
COPY . .
WORKDIR "/src/MassTransit.GettingStarted.Consumer"
RUN dotnet build "MassTransit.GettingStarted.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MassTransit.GettingStarted.Consumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MassTransit.GettingStarted.Consumer.dll"]