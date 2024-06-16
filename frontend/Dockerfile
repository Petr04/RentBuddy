FROM node:18-alpine AS build
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

# If server-side rendering is enabled
CMD ["node", "dist/rent-buddy/server/server.mjs"]

# If server-side rendering is disabled
# FROM nginx
# COPY --from=build /usr/src/app/dist/rent-buddy/browser /usr/share/nginx/html
