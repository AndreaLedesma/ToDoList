using ListaTareas.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaTareas.Server.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TareaController : ControllerBase
	{
		private ToDoListContext _dbContext;

		public TareaController(ToDoListContext context) 
		{
			_dbContext = context;
		}

		[HttpGet]
		public async Task<List<Tarea>> ObtenerTareas() => 
			await _dbContext.Tareas.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> ObtenerTarea_Id(int id)
        {
            var tarea = await _dbContext.Tareas.FirstOrDefaultAsync(t => t.TareaID == id);

            if (tarea == null)
                return NotFound();

            return Ok(tarea);
        }

        [HttpPost]
		public async Task<ActionResult> InsertarTarea(Tarea NuevaTarea)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				_dbContext.Tareas.Add(NuevaTarea);
				await _dbContext.SaveChangesAsync();
				return Ok("Tarea creada");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error al insertar la tarea: {ex.Message}");
			}
		}


		[HttpPut("{id}")]
		public async Task<ActionResult> EditarTarea_Id(int id, Tarea tareaActualizada)
		{
			if (id != tareaActualizada.TareaID)
				return BadRequest("Error, el Id de la tarea no coincide");

			try
			{
				var tarea = await _dbContext.Tareas.FindAsync(id);

				if (tarea == null)
					return NotFound();

				tarea.Titulo = tareaActualizada.Titulo;
				tarea.Descripcion = tareaActualizada.Descripcion;
				tarea.FechaVencimiento = tareaActualizada.FechaVencimiento;
				tarea.Estado = tareaActualizada.Estado;

				_dbContext.Entry(tarea).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();

				return Ok("Tarea actualizada"); 
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error al editar la tarea: {ex.Message}");
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> EditarEstadoTarea_Id(int id)
		{
			try
			{
				var tarea = await _dbContext.Tareas.FindAsync(id);

				if (tarea == null)
					return NotFound();

				if (tarea.Estado)
					tarea.Estado = false;
				else
					tarea.Estado = true;

				_dbContext.Entry(tarea).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();

				return Ok("El estado ha cambiado"); 
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error al cambiar el estado de la tarea: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> EliminarTarea_Id(int id)
		{
			try
			{
				var tarea = await _dbContext.Tareas.FindAsync(id);

				if (tarea == null)
					return NotFound();

				_dbContext.Tareas.Remove(tarea);
				await _dbContext.SaveChangesAsync();

				return Ok("Tarea eliminada"); 
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error al eliminar la tarea: {ex.Message}");
			}
		}
	}
}
