FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MiPrimerWebApiM3/MiPrimerWebApiM3.csproj", "MiPrimerWebApiM3/"]
RUN dotnet restore "MiPrimerWebApiM3/MiPrimerWebApiM3.csproj"
COPY . .
WORKDIR "/src/MiPrimerWebApiM3"
RUN dotnet build "MiPrimerWebApiM3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiPrimerWebApiM3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiPrimerWebApiM3.dll"]