# Configuración de la API y Base de Datos para **MAUIAPPREPRODUCTOR**

Este documento describe los pasos para crear y ejecutar la API y la base de datos utilizadas en el proyecto **MAUIAPPREPRODUCTOR**.

## Crear la Red de Docker

Se crea una red de Docker para conectar los contenedores de la API y la base de datos. Esto asegura que ambos contenedores puedan comunicarse entre sí.

```bash
docker network create musicfx-api-network
```
```bash
docker run -d --network musicfx-api-network -v musicfx-api-db:/var/lib/postgresql/data -e POSTGRES_USER=musicfx -e POSTGRES_PASSWORD=musicfx -e POSTGRES_DB=musicfx --name db postgres
```
```bash
docker run --network musicfx-api-network -v musicfx-api-data:/data -e FANART_API_KEY=your_fanart_api_key -e DB_TYPE=postgres -p 8080:80 --name musicfx-api javierpalacios/musicfx-api
```
