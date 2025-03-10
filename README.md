# Proyecto MauiAppReproductor

Este proyecto utiliza Docker para configurar y ejecutar una base de datos PostgreSQL y una API para gestionar la reproducción de música.

## Comandos para ejecutar el proyecto

### 1. Crear una red de Docker
Primero, creamos una red personalizada para conectar los contenedores:

```bash
docker network create musicfx-api-network
