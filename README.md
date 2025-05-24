# GeoMottuApi

## 📝 Descrição do Projeto
GeoMottuApi é uma API REST desenvolvida em .NET 8.0 para gerenciamento de filiais, pátios, motos e usuários da Mottu. A API permite o cadastro, consulta, atualização e remoção de informações relacionadas a estes recursos, facilitando a gestão da empresa em diferentes países.

## 🛣️ Rotas da API

### Usuários
- `POST /api/Usuario` - Cadastra um novo usuário
- `GET /api/Usuario` - Lista todos os usuários
- `GET /api/Usuario/{id}` - Busca um usuário por ID
- `GET /api/Usuario/email/{email}` - Busca um usuário por email
- `PUT /api/Usuario/update/{id}` - Atualiza dados de um usuário
- `DELETE /api/Usuario/delete/{id}` - Remove um usuário

### Motos
- `POST /api/Moto` - Cadastra uma nova moto
- `GET /api/Moto` - Lista todas as motos
- `GET /api/Moto/{id}` - Busca uma moto por ID
- `GET /api/Moto/modelo/{modelo}` - Busca motos por modelo
- `PUT /api/Moto/update/{id}` - Atualiza dados de uma moto
- `DELETE /api/Moto/delete/{id}` - Remove uma moto

### Filiais
- `POST /api/Filial` - Cadastra uma nova filial
- `GET /api/Filial` - Lista todas as filiais
- `GET /api/Filial/{id}` - Busca uma filial por ID
- `GET /api/Filial/pais/{pais}` - Busca filiais por país
- `PUT /api/Filial/update/{id}` - Atualiza dados de uma filial
- `DELETE /api/Filial/delete/{id}` - Remove uma filial

### Pátios
- `POST /api/Patio` - Cadastra um novo pátio
- `GET /api/Patio` - Lista todos os pátios
- `GET /api/Patio/{id}` - Busca um pátio por ID
- `GET /api/Patio/tipo/patio/{patio}` - Busca pátios por tipo
- `PUT /api/Patio/update/{id}` - Atualiza dados de um pátio
- `DELETE /api/Patio/delete/{id}` - Remove um pátio

## 🚀 Instalação e Configuração

### Pré-requisitos
- .NET 8.0 SDK
- Oracle Database
- Docker (opcional)

### Configuração Local
1. Clone o repositório
```bash
git clone [url-do-repositorio]
```

2. Navegue até a pasta do projeto
```bash
cd GeoMottuApi
```

3. Restaure as dependências
```bash
dotnet restore
```

4. Configure a string de conexão com o Oracle no arquivo `appsettings.json`
```json
{
  "ConnectionStrings": {
    "Oracle": "sua-string-de-conexao"
  }
}
```

5. Execute o projeto
```bash
dotnet run
```

A API estará disponível em:
- http://localhost:5280 (HTTP)

A documentação Swagger estará disponível em:
- http://localhost:5280/swagger

## 🐳 Docker

Para criar um Dockerfile para este projeto, você pode usar o seguinte conteúdo:

```dockerfile
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
```

### Construindo e Executando com Docker

1. Construa a imagem:
```bash
docker build -t geomottuapi .
```

2. Execute o container:
```bash
docker run -d -p 8080:8080 --name geomottuapi geomottuapi
```

A API estará disponível em:
- http://localhost:8080
- http://localhost:8080/swagger (documentação)

### Explicação do Dockerfile
- `FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build`: Imagem base para compilação com SDK .NET 8.0
- `COPY . .`: Copia todo o código fonte para o container
- `RUN dotnet restore`: Restaura todas as dependências do projeto
- `RUN dotnet publish`: Compila e publica o projeto em modo Release
- `FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime`: Usa uma imagem Alpine Linux mais leve para o runtime
- `RUN adduser -D appuser`: Cria um usuário não-root para maior segurança
- `COPY --from=build /app/publish ./`: Copia apenas os arquivos necessários do estágio de build
- `COPY GeoMottuApi/appsettings.json ./`: Garante que as configurações estejam disponíveis
- `RUN chown -R appuser:appuser /app`: Ajusta as permissões dos arquivos
- `USER appuser`: Muda para o usuário não-root por segurança
- `EXPOSE 8080`: Expõe a porta que será usada pela aplicação
- `ENTRYPOINT ["dotnet", "GeoMottuApi.dll"]`: Define o comando de inicialização

### Boas Práticas Implementadas
1. **Multi-stage build**: Reduz o tamanho final da imagem
2. **Imagem Alpine**: Usa uma imagem base mais leve e segura
3. **Usuário não-root**: Aumenta a segurança da aplicação
4. **Separação de camadas**: Otimiza o cache do Docker
5. **Configuração explícita**: Garante que as configurações estejam disponíveis

## 🚀 Implantação na Azure

### Script de Criação da VM
Salve o script abaixo como `createvm.sh`:

```bash
#!/bin/bash

# Variáveis
RESOURCE_GROUP="rg-geomottu"
LOCATION="brazilsouth"
VM_NAME="vm-geomottu"
IMAGE="almalinux:almalinux-x86_64:9-gen2:9.5.202411260"
SIZE="Standard_D2s_v3"
ADMIN_USERNAME="sunauezuri"
ADMIN_PASSWORD="Fiap@2tdsvms"
DISK_SKU="StandardSSD_LRS"

# Criar grupo de recursos
echo "Criando grupo de recursos: $RESOURCE_GROUP..."
az group create --name $RESOURCE_GROUP --location $LOCATION

# Criar a VM
echo "Criando a máquina virtual: $VM_NAME, por favor aguarde..."
az vm create \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --image $IMAGE \
  --size $SIZE \
  --authentication-type password \
  --admin-username $ADMIN_USERNAME \
  --admin-password $ADMIN_PASSWORD \
  --storage-sku $DISK_SKU \
  --public-ip-sku Basic

echo "Abrindo porta 5000 para aplicação..."
az vm open-port --port 5000 --resource-group $RESOURCE_GROUP --name $VM_NAME --priority 1002

echo "Abrindo porta 8080 para aplicação..."
az vm open-port --port 8080 --resource-group $RESOURCE_GROUP --name $VM_NAME --priority 1003

echo "VM Criada com sucesso!"
```

### Explicação do Script
- `RESOURCE_GROUP`: Nome do grupo de recursos que conterá a VM
- `LOCATION`: Região da Azure onde a VM será criada (Brazil South)
- `VM_NAME`: Nome da máquina virtual
- `IMAGE`: Imagem do sistema operacional (AlmaLinux 9)
- `SIZE`: Tamanho da VM (2 vCPUs, 8GB RAM)
- `ADMIN_USERNAME`: Nome do usuário administrador
- `ADMIN_PASSWORD`: Senha do usuário administrador
- `DISK_SKU`: Tipo de disco (SSD Standard)

O script também:
1. Cria um grupo de recursos na Azure
2. Provisiona uma VM com as especificações definidas
3. Abre as portas 5000 e 8080 para a aplicação

### Configurando a VM e Implantando a Aplicação

1. **Conecte-se à VM via SSH**:
```bash
ssh sunauezuri@<ip-publico-da-vm>
```
> O IP público pode ser encontrado no portal da Azure

2. **Instale o Git**:
```bash
sudo dnf update -y
sudo dnf install git -y
```

3. **Instale o Docker**:
```bash
sudo dnf install docker -y
```

4. **Clone e Configure o Projeto**:
```bash
# Clone o repositório
git clone [url-do-repositorio]
cd GeoMottuApi

# Configure as variáveis de ambiente se necessário
# Edite o arquivo appsettings.json com as configurações corretas
```

5. **Build e Execute o Container**:
```bash
# Construa a imagem Docker
docker build -t geomottuapi .

# Execute o container
docker run -d -p 8080:8080 --name geomottuapi geomottuapi
```

### Verificando a Aplicação

1. **Teste o acesso**:
- API: `http://<ip-publico-da-vm>:8080`
- Swagger: `http://<ip-publico-da-vm>:8080/swagger`

2. **Visualize os logs do container**:
```bash
docker logs geomottuapi
```

3. **Comandos úteis de manutenção**:
```bash
# Parar o container
docker stop geomottuapi

# Iniciar o container
docker start geomottuapi

# Remover o container
docker rm -f geomottuapi

# Visualizar containers em execução
docker ps
```


## 🛠️ Tecnologias Utilizadas
- .NET 8.0
- Entity Framework Core
- Oracle EntityFrameworkCore
- Swagger/OpenAPI 
