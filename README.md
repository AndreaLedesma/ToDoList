-Base de datos-
*Crear una base de datos vacía con el nombre: ToDoList
*Cambiar la conexión a SQL en: ToDoList\ListaTareas\ListaTareas\Server\appsettings.json
  la propiedad es ToDoListConnection.
*La migración se hace una vez se ejecuta el proyecto.
*Por alguna razón la primera ejecución en mi equipo no mostró nada y se sólo se puso la ventana del navegador en blanco, 
  lo detuve y lo volví a ejecutar y funcionó bien, no me volvió a pasar. En caso de que 
  suceda, favor de hacer lo mismo. 
-API-
*El api se encuentra en la siguiente ruta: ToDoList\ListaTareas\ListaTareas\Server\Controllers\TareaController.cs
*Para probar el api en Postman o similar es desde sólo se añade /api/Tarea/NombreMetodo a la url que genera el proyecto por defecto
  para ObtenerTarea_Id, EditarEstadoTarea_Id, EliminarTarea_Id, EditarTarea_Id, se debe añadir el número de id al final /api/Tarea/NombreMetodo/id 
  para InsertarTarea y EditarTarea_Id se debe añadir un JSON en el Body.
-Cliente-
*Los métodos del cliente en la siguiente ruta: ToDoList\ListaTareas\ListaTareas\Client\Services\srv_PeticionHTTP.cs
-Modelo-
*El modelo en la ruta: ToDoList\ListaTareas\ListaTareas\Shared\ListaTareas.Shared.csproj
-Pruebas Unitarias-
*Por último las pruebas: ToDoList\ListaTareas\ToDoListTest\TareaTest.cs
  mi experiencia en pruebas unitarias es nula, no estoy segura de sí fui por buen camino, 
  para ejecutarlas no hace falta agregar nada, pero se pueden cambias la información de las listas de tareas de ejemplo. 
