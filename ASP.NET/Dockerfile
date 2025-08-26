# Use a imagem oficial do SDK do .NET para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia e restaura as dependências do projeto
COPY *.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos e constrói a aplicação
COPY . .
RUN dotnet publish -c Release -o out

# Use a imagem de runtime para o ambiente final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ASP.NET.dll"]