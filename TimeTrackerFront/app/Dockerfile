# Use uma imagem base de Node.js para build
FROM node:18 AS build
WORKDIR .
COPY app/package.json ./
COPY app/package-lock.json ./
RUN npm install
COPY app/ .
EXPOSE 8080
RUN npm run build
CMD [ "npm", "run", "dev" ]

# Use uma imagem leve do nginx para servir a aplicação
FROM nginx:alpine
COPY app/nginx.conf /etc/nginx/nginx.conf
COPY --from=build app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
