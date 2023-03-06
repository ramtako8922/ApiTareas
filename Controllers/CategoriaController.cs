using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTareas.Models;
using ApiTareas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CategoriaController :ControllerBase

    {
       ICategoriaService categoriaService; 

       public CategoriaController(ICategoriaService Service)
       {
         categoriaService=Service;
       }

       [HttpGet]
       [Route("api/obtener")]
       public IActionResult Get(){
        
        return Ok(categoriaService.Get());
       }
        [HttpPost]
        [Route("api/agregar")]
       public IActionResult Post( [FromBody] Categoria categoria){
        categoriaService.Save(categoria);
        return Ok();
       }

       [HttpPut]
        [Route("api/actualizar/{id}")]
       public IActionResult Put( Guid id, [FromBody] Categoria categoria){
        categoriaService.Update(id,categoria);
        return Ok();
       }

        [HttpDelete]
        [Route("api/eliminar/{id}")]
       public IActionResult Delete( Guid id){
        categoriaService.Delete(id);
        return Ok();
       }
        
   }
}