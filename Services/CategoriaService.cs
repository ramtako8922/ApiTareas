using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTareas.Models;

namespace ApiTareas.Services
{
    public class CategoriaService: ICategoriaService
    {
        ApiTareas.TareasContex context;

        public CategoriaService(TareasContex dBcontex)
        {
            context=dBcontex;
        }

        public IEnumerable<Categoria> Get(){

            return context.Categorias;

        }

        public async Task  Save(Categoria categoria){

          context.Add(categoria);
          await context.SaveChangesAsync();

        }

        public async Task  Update( Guid id,Categoria categoria){

          var CategoriaActual=context.Categorias.Find(id);

          if (CategoriaActual!=null)
          {
           CategoriaActual.Nombre=categoria.Nombre;
           CategoriaActual.Descripcion=categoria.Descripcion;
           CategoriaActual.Esfuerzo=categoria.Esfuerzo;
            
            await context.SaveChangesAsync();
          }
         
         

          

        }


        public async Task  Delete( Guid id){

          var CategoriaActual=context.Categorias.Find(id);

          if (CategoriaActual!=null)
          {
             context.Remove(CategoriaActual);
            await context.SaveChangesAsync();
          }
         
         

          

        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
       
        Task  Save(Categoria categoria);
         Task  Update( Guid id,Categoria categoria);
          Task  Delete( Guid id);
    }
}