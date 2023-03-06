using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiTareas.Models;
using ApiTareas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiTareas.Controllers
{
    [Route("[controller]")]
    public class TareaController : ControllerBase
    {ITareaService tareaService; 

       public TareaController(ITareaService Service)
       {
         tareaService=Service;
       }

       [HttpGet]
       [Route("api/tarea/obtener")]
       public IActionResult Get(){
        
        return Ok(tareaService.Get());
       }
        [HttpPost]
        [Route("api/tarea/agregar")]
       public IActionResult Post( [FromBody] Tarea tarea ){
    tareaService.Save(tarea);
        return Ok();
       }

       
       [HttpPut]
        [Route("api/tarea/actualizar/{id}")]
       public IActionResult Put( Guid id, [FromBody] Tarea tarea){

        tareaService.Update(id,tarea);
        return Ok();
       }

        [HttpDelete]
        [Route("api/tarea/eliminar/{id}")]
       public IActionResult Delete( Guid id){
        tareaService.Delete(id);
        return Ok();

       }
       
       }
        
   }

