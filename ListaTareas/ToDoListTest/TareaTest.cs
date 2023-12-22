using ListaTareas.Client.Services;
using ListaTareas.Server.Controllers;
using ListaTareas.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Net;

namespace ToDoListTest
{
    public class TareaTest
    {
        private readonly PeticionHTTP _peticiones;
        public readonly HttpClient _httpClient;

        public TareaTest()
        {
            _httpClient = new HttpClient();
            _peticiones = new PeticionHTTP(_httpClient);
        }


        /// <summary>
        /// Búsqueda de toas las tareas
        /// </summary>
        [Fact]
        public void ObtenerTareas_Ok()
        {
            // Arrange
            var expectedTareas = new List<Tarea> { 
            
                new Tarea { Titulo = "Cena de navidad", Descripcion = "Comprar refrescos", FechaVencimiento = new DateTime(2023, 12, 23)},
                new Tarea { Titulo = "Mascotas", Descripcion = "Cepillar pelo", FechaVencimiento = new DateTime(2023, 12, 27)},
                new Tarea { Titulo = "Mandado", Descripcion = "Comprar huevos, harina y leche", FechaVencimiento = new DateTime(2023, 12, 27)},

            };
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(expectedTareas)
            };

            //act
            var result = _peticiones.ObtenerTareas();

            //assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Búsqueda por ID
        /// </summary>
        [Fact]
        public void ObtenerTarea_Id_Ok()
        {
            // Arrange
            var expectedTareas = new List<Tarea> { 
            
                new Tarea { TareaID = 1, Titulo = "Cena de navidad", Descripcion = "Comprar refrescos", FechaVencimiento = new DateTime(2023, 12, 23)},
                new Tarea { TareaID = 2, Titulo = "Mascotas", Descripcion = "Cepillar pelo", FechaVencimiento = new DateTime(2023, 12, 27)},
                new Tarea { TareaID = 3, Titulo = "Mandado", Descripcion = "Comprar huevos, harina y leche", FechaVencimiento = new DateTime(2023, 12, 27)},

            };
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(expectedTareas)
            };

            //act
            var result = _peticiones.ObtenerTarea_Id(2);

            //assert
            Assert.NotNull(result);
        }
    }
}