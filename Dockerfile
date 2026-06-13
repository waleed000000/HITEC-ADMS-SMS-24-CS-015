FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["StudentManagementSystem/StudentManagementSystem.csproj", "StudentManagementSystem/"]
RUN dotnet restore "StudentManagementSystem/StudentManagementSystem.csproj"
COPY . .
WORKDIR "/src/StudentManagementSystem"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentManagementSystem.dll"]
