# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo o código fonte
COPY . .

# Restaura dependências
RUN dotnet restore

# Publica em Release
RUN dotnet publish GeoMottuApi/GeoMottuApi.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app

# Cria um usuário não root
RUN adduser -D appuser

# Copia os arquivos publicados do build
COPY --from=build /app/publish ./

# Copia arquivos de configuração
COPY GeoMottuApi/appsettings.json ./appsettings.json

# Altera propriedade dos arquivos para o novo usuário
RUN chown -R appuser:appuser /app

# Troca para o usuário não root
USER appuser

# Expõe a porta usada pelo Kestrel
EXPOSE 8080

# Entry point da aplicação
ENTRYPOINT ["dotnet", "GeoMottuApi.dll"]
