#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cynet/Cynet.csproj", "Cynet/"]
COPY ["Cynet.EF/Cynet.EF.csproj", "Cynet.EF/"]
COPY ["Cynet.Domain/Cynet.Domain.csproj", "Cynet.Domain/"]
COPY ["Cynet.Common/Cynet.Common.csproj", "Cynet.Common/"]
RUN dotnet restore "Cynet/Cynet.csproj"
COPY . .
WORKDIR "/src/Cynet"
RUN dotnet build "Cynet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cynet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cynet.dll"]