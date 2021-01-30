FROM node as builder
RUN mkdir /src
WORKDIR /src

COPY package.json ./
RUN npm i

COPY . .
RUN npm run build

FROM nginx:alpine as webserver
WORKDIR /usr/share/nginx/html
COPY --from=builder /src/dist .

EXPOSE 80
