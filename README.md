# EventosDeportivos-Backend

Backend de Proyecto Final de asignatura "Sistemas Distribuidos Y Programacion en Paralelo".

## Descripción:

El proyecto consta de una aplicacion para comprar tickets a eventos deportivos de diferentes categorias.

## Rutas 

### Eventos: (/api/eventos)
- POST   / Crear eventos
- GET    / Obtener uno o todos los eventos
- PUT    / Editar evento
- DELETE / Borrar un evento

### Clientes: (/api/customer)
- POST   / Registrar
- GET    / Obtener uno o todos los clientes
- PUT    / Editar clientes
- DELETE / Borrar un cliente

### Login: (/api/login)
- POST   / Logear al Usuario obtenes tokens

### Refresh: (/api/refresh)
- POST   / Refrescar tokens de clientes (Token y Refresh Token )

### Auth: (/api/refresh)
- POST   / Obtener datos de usuario a partir de token

### Reservas: (/api/reservation)
- POST   / Crear reservas
- GET    / Obtener una o todas las reservas
- GET    / Cancelar una reserva


## Arquitectura
![arquitectura](https://github.com/Woohaik/EventosDeportivos-Backend/blob/master/Arquitectura.jpg)
