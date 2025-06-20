# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj e restaura
COPY ["SIAVIBioFITBackEnd.csproj", "."]
RUN dotnet restore "SIAVIBioFITBackEnd.csproj"

# Copia tudo e compila
COPY . .
RUN dotnet publish "SIAVIBioFITBackEnd.csproj" -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Render define a porta na variável de ambiente PORT
ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "SIAVIBioFITBackEnd.dll"]
