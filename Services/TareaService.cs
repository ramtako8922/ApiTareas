using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTareas.Models;

namespace ApiTareas.Services
{
    public class TareaService :ITareaService
    {
            TareasContex context;

        public TareaService(TareasContex dBcontex)
        {
            context=dBcontex;
        }

        public IEnumerable<Tarea> Get(){

            return context.Tareas;

        }

        public async Task  Save(Tarea tarea){

          context.Add(tarea);
          await context.SaveChangesAsync();

        }

        public async Task  Update( Guid id,Tarea tarea){

          var TareaActual=context.Tareas.Find(id);

          if (TareaActual!=null)
          {
           TareaActual.CategoriaId=tarea.CategoriaId;
           TareaActual.Titulo=tarea.Titulo;
           TareaActual.Descripcion=tarea.Descripcion;
           TareaActual.PrioridadTarea=tarea.PrioridadTarea;
           TareaActual.Responsable=tarea.Responsable;
            
            await context.SaveChangesAsync();
          }
         
         

          

        }


        public async Task  Delete( Guid id){

          var TareaActual=context.Tareas.Find(id);

          if (TareaActual!=null)
          {
             context.Remove(TareaActual);
            await context.SaveChangesAsync();
          }
         
         

          

        }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> Get();
       
        Task  Save(Tarea tarea);
         Task  Update( Guid id,Tarea tarea);
          Task  Delete( Guid id);
    }
}