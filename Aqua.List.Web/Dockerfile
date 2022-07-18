FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aqua.List/Aqua.List.csproj", "Aqua.List/"]
RUN dotnet restore "Aqua.List/Aqua.List.csproj"
COPY . .
WORKDIR "/src/Aqua.List"
RUN dotnet build "Aqua.List.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aqua.List.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aqua.List.dll"]
