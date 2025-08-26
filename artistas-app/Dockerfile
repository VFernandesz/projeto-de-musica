# Use a imagem oficial do Node para construir e executar a aplicação
FROM node:18-alpine
WORKDIR /app

# Copia os arquivos de configuração do projeto e instala as dependências
COPY package*.json ./
RUN npm install

# Copia o restante do código
COPY . .

# Expõe a porta que o Vite usa
EXPOSE 5173

# Comando para iniciar o servidor de desenvolvimento
CMD ["npm", "run", "dev", "--", "--host"]