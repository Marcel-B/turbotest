FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aqua.List.Web/Aqua.List.Web.csproj", "Aqua.List.Web/"]
RUN dotnet restore "Aqua.List.Web/Aqua.List.Web.csproj"
COPY . .
WORKDIR "/src/Aqua.List.Web"
RUN dotnet build "Aqua.List.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aqua.List.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aqua.List.Web.dll"]

# docker buildx build -f ./Aqua.List.Web/Dockerfile --platform linux/amd64 --push -t  millegalb/aqua.list.web:2.0.18 .
