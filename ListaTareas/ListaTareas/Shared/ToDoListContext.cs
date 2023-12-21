using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareas.Shared
{
    public class ToDoListContext : DbContext
    {

        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) 
        {
            
        }

        public DbSet<Tarea> Tareas { get; set; }

        /// <summary>
        /// Cambiando el nombre de la Tabla, Tareas -> Tarea
        /// </summary>       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().ToTable("Tarea");   
        }
    }
}
