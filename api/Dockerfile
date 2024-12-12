# Use a .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY employee-api/*.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the application
COPY employee-api/. ./
RUN dotnet publish -c Release -o /out

# Use a lightweight runtime image for deployment
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy the built application
COPY --from=build /out ./

# Copy TLS certificates into the container
COPY certs/employee_api.p12 /certs/employee_api.p12
COPY certs/employee_api.crt /certs/employee_api.crt

# Set environment variables for TLS
ENV DOTNET_KESTREL__ENDPOINTS__HTTPS__URLS="https://*:8080"
ENV DOTNET_KESTREL__ENDPOINTS__HTTPS__CERTIFICATE__PATH="/certs/employee_api.p12"
ENV DOTNET_KESTREL__ENDPOINTS__HTTPS__CERTIFICATE__PASSWORD="changeit"

# Expose HTTPS port
EXPOSE 8080

# Set the entry point
ENTRYPOINT ["dotnet", "employee-api.dll"]
