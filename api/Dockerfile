FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY employee-api/*.csproj ./
RUN dotnet restore

COPY employee-api/. ./
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /out ./

COPY certs/employee_api.p12 /certs/employee_api.p12
COPY certs/employee_api.crt /certs/employee_api.crt

ENV DOTNET_KESTREL__ENDPOINTS__HTTPS__URLS="https://*:8080"
ENV DOTNET_KESTREL__ENDPOINTS__HTTPS__CERTIFICATE__PATH="/certs/employee_api.p12"
ENV DOTNET_KESTREL__ENDPOINTS__HTTPS__CERTIFICATE__PASSWORD="changeit"

EXPOSE 8080

ENTRYPOINT ["dotnet", "employee-api.dll"]
