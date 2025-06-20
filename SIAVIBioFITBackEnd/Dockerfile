# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia o csproj e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o resto do código e compila
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copia a build final
COPY --from=build /app/out .

# Render define a porta como variável de ambiente $PORT
ENV ASPNETCORE_URLS=http://+:$PORT

# Inicia a aplicação
ENTRYPOINT ["dotnet", "SIAVIBioFITBackEnd.dll"]
