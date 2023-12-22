
using ListaTareas.Shared;
using System.Net.Http.Json;

namespace ListaTareas.Client.Services
{
    public interface IPeticionHTTP
    {
        public Task<List<Tarea>?> ObtenerTareas();
        public Task<Tarea?> ObtenerTarea_Id(int Id);
        public Task<string> InsertarTarea(Tarea NuevaTarea);
        public Task<string> EditarTarea_Id(int Id, Tarea TareaActualizada);
        public Task<string> EditarEstadoTarea_Id(int Id);
        public Task<string> EliminarTarea_Id(int Id);

    }   
    public class PeticionHTTP:IPeticionHTTP
    {
        public readonly HttpClient _httpClient;

        public PeticionHTTP(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Obtiene la lista completa de tareas
        /// </summary>
        /// <returns>IEnumerable<Tarea>?</returns>
        public async Task<List<Tarea>?> ObtenerTareas()
        {
            HttpResponseMessage response = await _httpClient
                .GetAsync($"api/Tarea/ObtenerTareas");
            try
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content
                        .ReadFromJsonAsync<List<Tarea>>();
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Obtine la tarea por Id
        /// </summary>
        /// <param name="Id">Id a consutar</param>
        /// <returns>Tarea</returns>
        public async Task<Tarea?> ObtenerTarea_Id(int Id)
        {
            HttpResponseMessage response = await _httpClient
                .GetAsync($"api/Tarea/ObtenerTarea_Id/{Id}");
            try
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<Tarea>();
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Inserta una nueva tarea
        /// </summary>
        /// <param name="NuevaTarea">Tarea a insertar</param>
        /// <returns>string, mensaje de confirmación</returns>
        public async Task<string> InsertarTarea(Tarea NuevaTarea)
        {
            HttpResponseMessage response = await _httpClient
                .PostAsJsonAsync($"api/Tarea/InsertarTarea", NuevaTarea);
            try
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                    return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return $"Error al realizar la petición {ex.Message}";
            }
        }

        /// <summary>
        /// Actuaiza la tarea especificada por id 
        /// </summary>
        /// <param name="Id">Id de la tarea a editar</param>
        /// <param name="TareaActualizada">Tarea con la nueva información</param>
        /// <returns>string, mensaje de confirmación</returns>
        public async Task<string> EditarTarea_Id(int Id, Tarea TareaActualizada)
        {
            HttpResponseMessage response = await _httpClient
                .PutAsJsonAsync($"api/Tarea/EditarTarea_Id/{Id}", TareaActualizada);
            try
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                    return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return $"Error al realizar la petición {ex.Message}";
            }
        }

        /// <summary>
        /// Actualiza el estado de la tarea 
        /// pendiente a completado 
        /// completado a pendiente
        /// </summary>
        /// <param name="Id">Id de la tarea a editar</param>
        /// <returns>string, mensaje de confirmación</returns>
        public async Task<string> EditarEstadoTarea_Id(int Id)
        {
            HttpResponseMessage response = await _httpClient
                .PutAsync($"api/Tarea/EditarEstadoTarea_Id/{Id}", null);
            try
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                    return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return $"Error al realizar la petición {ex.Message}";
            }
        }

        /// <summary>
        /// Elimina definitivamente la tarea
        /// </summary>
        /// <param name="Id">Id de la tarea a eliminar</param>
        /// <returns>string, mensaje de confirmación</returns>
        public async Task<string> EliminarTarea_Id(int Id)
        {
            HttpResponseMessage response = await _httpClient
                .DeleteAsync($"api/Tarea/EliminarTarea_Id/{Id}");
            try
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                    return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return $"Error al realizar la petición {ex.Message}";
            }
        }
    }
}
