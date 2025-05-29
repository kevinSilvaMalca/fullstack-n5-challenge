# 🐳 Docker Compose - FullStack Challenge

Este archivo `docker-compose.yml` orquesta los servicios necesarios para ejecutar el sistema completo.

## Servicios incluidos

- **sqlserver**: SQL Server 2022, usado como base de datos relacional principal.
- **elasticsearch**: Base de datos NoSQL orientada a búsqueda y analítica.
- **kibana**: Interfaz web para visualizar los datos de Elasticsearch.
- **zookeeper + kafka**: Sistema de mensajería distribuida (Kafka) y su coordinador (Zookeeper).
- **backend**: API REST en ASP.NET Core, expuesta en el puerto `5147`.
- **frontend**: Aplicación web (React o similar), accesible en `http://localhost:3000`.

## Uso básico

```bash
docker compose build
docker compose up
```

Esto construirá e iniciará todos los servicios necesarios.

> Asegúrate que el puerto `5147` no esté en uso antes de levantar el backend.

---
