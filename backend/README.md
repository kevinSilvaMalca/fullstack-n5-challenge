# 🔧 Backend - ASP.NET Core

Este proyecto contiene una API REST para gestionar permisos (`Permissions`).

## Estructura principal

- `Controllers/`: Controladores de endpoints REST.
- `Services/`: Lógica de negocio.
- `Infrastructure/`: Repositorios y DbContext.
- `Domain/`: Entidades del modelo.
- `Program.cs`: Configuración de servicios, middlewares, Swagger, EF, Kafka y Elasticsearch.

## Base de datos

Se usa SQL Server. El `DbContext` aplica automáticamente migraciones al iniciar el backend usando:

```csharp
dbContext.Database.Migrate();
```

## Migraciones

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Kafka y Elasticsearch

- Usa `Confluent.Kafka` para publicar eventos.
- Usa `Elasticsearch.Net` para indexar datos.

> El backend se expone en `http://localhost:5147`.

---

## 📊 Validación en Kibana (Elasticsearch)

Una vez que el backend esté en ejecución y hayas enviado datos (POST a `/api/permissions`), puedes verificar que se están guardando correctamente en **Elasticsearch** usando Kibana:

### 🧭 Acceso a Kibana

1. Abre tu navegador y ve a:  
   👉 [http://localhost:5601](http://localhost:5601)

2. En el menú lateral izquierdo, haz clic en **“Dev Tools”**.

3. Ejecuta la siguiente consulta para obtener los últimos datos indexados:

```json
GET permissions/_search
{
  "query": {
    "match_all": {}
  },
  "size": 10
}
```

### 🔍 Consulta para ver campos específicos

```json
GET permissions/_search
{
  "_source": ["employeeName", "employeeLastName", "permissionDate", "permissionTypeId"],
  "query": {
    "match_all": {}
  },
  "size": 10
}
```

### ✅ Resultado esperado

Un ejemplo de respuesta válida:

```json
{
  "hits": {
    "hits": [
      {
        "_source": {
          "employeeName": "Kevin",
          "employeeLastName": "Silva",
          "permissionDate": "2025-05-28",
          "permissionTypeId": 1
        }
      }
    ]
  }
}
```

Incluye esta verificación como parte del proceso de testing para demostrar que el sistema está indexando datos correctamente.


---

## 🔄 Actualización de permisos

El sistema también soporta la edición de permisos existentes.

### Endpoint `PUT /api/permissions/{id}`

Este endpoint permite actualizar los datos de un permiso existente por su `id`.

#### 🔧 Ejemplo de cuerpo (`JSON`):

```json
{
  "employeeName": "Kevin",
  "employeeLastName": "Silva",
  "permissionDate": "2025-06-01",
  "permissionTypeId": 2
}
```

- `employeeName`: Nombre del empleado.
- `employeeLastName`: Apellido del empleado.
- `permissionDate`: Nueva fecha del permiso.
- `permissionTypeId`: Identificador del tipo de permiso.

#### ✅ Resultado esperado

```json
{
  "id": 1,
  "employeeName": "Kevin",
  "employeeLastName": "Silva",
  "permissionDate": "2025-06-01",
  "permissionType": {
    "id": 2,
    "description": "Nuevo tipo"
  }
}
```

Asegúrate de que el ID proporcionado en la URL exista en la base de datos.

---

## ✅ Validación en Kibana luego del `PUT`

Al ejecutar un `PUT`, los cambios también se reflejan en **Elasticsearch**.

Puedes validar los cambios con esta query en Dev Tools de Kibana:

```json
GET permissions/_search
{
  "query": {
    "match": {
      "employeeLastName": "Silva"
    }
  }
}
```
