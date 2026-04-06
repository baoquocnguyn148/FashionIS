# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["FashionStoreIS.slnx", "./"]
COPY ["FashionStoreIS/FashionStoreIS/FashionStoreIS.csproj", "FashionStoreIS/FashionStoreIS/"]
RUN dotnet restore "FashionStoreIS/FashionStoreIS/FashionStoreIS.csproj"

# Copy the rest of the code and build
COPY . .
WORKDIR "/src/FashionStoreIS/FashionStoreIS"
RUN dotnet build "FashionStoreIS.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "FashionStoreIS.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Render provides the PORT environment variable
# Program.cs is configured to listen on builder.WebHost.UseUrls($"http://0.0.0.0:{port}")
ENTRYPOINT ["dotnet", "FashionStoreIS.dll"]

