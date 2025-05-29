# 🌐 Frontend - React

Este frontend consume la API REST para mostrar, registrar y modificar permisos.

## Requisitos

- Node.js 18+
- Vite, React, Axios

## Scripts útiles

```bash
npm install
npm run dev  # En desarrollo
```

## CORS

El backend permite solicitudes desde:

- `http://localhost:5173`
- `http://localhost:3000`

## Docker

```bash
docker build -t frontend .
docker run -p 3000:80 frontend
```

> Verifica que el backend esté corriendo en `http://localhost:5147` antes de usar el frontend.

---
