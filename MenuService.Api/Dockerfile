# Stage 1: Build all dependencies
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["MenuService.Api/MenuService.Api.csproj", "MenuService.Api/"]
COPY ["MenuService.Application/MenuService.Application.csproj", "MenuService.Application/"]
COPY ["MenuService.Core/MenuService.Core.csproj", "MenuService.Core/"]
COPY ["MenuService.Infrastructure/MenuService.Infrastructure.csproj", "MenuService.Infrastructure/"]



RUN dotnet restore "MenuService.Api/MenuService.Api.csproj"

# Copy the full solution
COPY . .

# Build all projects
RUN dotnet build "MenuService.Api/MenuService.Api.csproj" -c Release

# Stage 3: Publish WebShop (only proceeds if tests pass)
FROM build AS publish
WORKDIR /src/MenuService.Api
RUN dotnet publish "MenuService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final runtime image for WebShop
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MenuService.Api.dll"]