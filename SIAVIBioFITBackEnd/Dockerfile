# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SIAVIBioFITBackEnd.csproj", "."]
RUN dotnet restore "SIAVIBioFITBackEnd.csproj"
COPY . .
RUN dotnet publish "SIAVIBioFITBackEnd.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SIAVIBioFITBackEnd.dll"]