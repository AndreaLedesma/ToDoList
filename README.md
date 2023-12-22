### Configuración del Proyecto ToDoList

#### Base de Datos
- Crear una base de datos vacía con el nombre: `ToDoList`.
- Cambiar la conexión a SQL en: `ToDoList\ListaTareas\ListaTareas\Server\appsettings.json`. La propiedad a modificar es `ToDoListConnection`.
- La migración se realiza al ejecutar el proyecto.

#### API
- La ruta de la API: `ToDoList\ListaTareas\ListaTareas\Server\Controllers\TareaController.cs`.
- Para probar el API en Postman u otro software similar, añadir `/api/Tarea/NombreMetodo` a la URL predeterminada del proyecto.
  - Para ObtenerTarea_Id, EditarEstadoTarea_Id, EliminarTarea_Id, EditarTarea_Id, agregar el número de ID al final `/api/Tarea/NombreMetodo/id`.
  - Para InsertarTarea y EditarTarea_Id, agregar un JSON en el cuerpo (Body) de la solicitud.

#### Cliente
- Los métodos del cliente se encuentran en: `ToDoList\ListaTareas\ListaTareas\Client\Services\srv_PeticionHTTP.cs`.
- Ya que tenía dudas respecto al cambio de estado y la eliminación realicé los 2 métodos por si las dudas, para el cambio de estado es dando clic en el checkbox y eliminar el registro definitivamente es en el botón del trash icon.

#### Modelo
- El modelo está ubicado en: `ToDoList\ListaTareas\ListaTareas\Shared\ListaTareas.Shared.csproj`.

#### Pruebas Unitarias
- Las pruebas unitarias están en: `ToDoList\ListaTareas\ToDoListTest\TareaTest.cs`.
- La experiencia en pruebas unitarias es limitada, por lo que no se asegura el enfoque correcto. No es necesario agregar nada para ejecutarlas, pero se puede modificar la información de las listas de tareas de ejemplo.
