## REST API

### Ejecutar

`dotnet run`

### PORT	

`http -> 5000`

`https -> 5001`

### Enviar Solicitud de Ingreso

#### Request

`POST /api/solicitud`

objeto

```js
{
    "nombre":"homer",
    "apellidos":"simpson",
    "identificacion":1155111,
    "edad":91,
    "casa":"Gryffindor"
}
```

### Actualizar solicitud de Ingreso

#### Request

`PUT /api/solicitud/:id`

objeto

```js
{
    "id": 11,
    "nombre":"homer",
    "apellidos":"simpson-",
    "identificacion":111,
    "edad":1,
    "casa":"Gryffindor"
}
```

### Consultar todas las solicitudes enviadas

#### Request

`GET /api/solicitud`

#### Response

```js
[
  {
    id: 11,
    nombre: "homer",
    apellidos: "simpson",
    identificacion: 1155111,
    edad: 91,
    casa: "Gryffindor",
  },
  {
    id: 12,
    nombre: "homer",
    apellidos: "simpson",
    identificacion: 1155111,
    edad: 91,
    casa: "Gryffindor",
  },
  {
    id: 13,
    nombre: "homer",
    apellidos: "simpson",
    identificacion: 1155111,
    edad: 91,
    casa: "Gryffindor",
  },
];
```

### Consultar solicitud Especifica

#### Request

`GET /api/solicitud/:id`

#### Response

```js

   {
       "id": 11,
       "nombre": "homer",
       "apellidos": "simpson",
       "identificacion": 1155111,
       "edad": 91,
       "casa": "Gryffindor"
   }

```

### Eliminar la solicitud de ingreso.

#### Request

`DELETE /api/solicitud/:id`

