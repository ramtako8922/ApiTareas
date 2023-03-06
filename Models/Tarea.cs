using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTareas.Models
{
    public class Tarea
    {
        //[Key]
        public Guid TareaId { get; set; }
       // [ForeignKey("CategoríaId")]
        public Guid CategoriaId { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Responsable { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Categoria Categoria { get; set; }
        //[NotMapped]
        public string Resumen { get; set; }
        
    }

    
}