FROM node:18-alpine AS build
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

CMD ["node", "dist/rent-buddy/server/server.mjs"]
