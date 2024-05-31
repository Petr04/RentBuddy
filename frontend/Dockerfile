FROM node:18-alpine AS build
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build
COPY dist/rent-buddy .

CMD ["node", "server/server.mjs"]
