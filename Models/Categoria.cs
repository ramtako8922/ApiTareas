using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiTareas.Models
{
    public class Categoria
    {
        //[Key]
        public Guid CategoriaId { get; set; }
        //[Required]
        //[MaxLength(150)]
        public String Nombre { get; set; }
        public String Descripcion { get; set; }

        public int Esfuerzo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}