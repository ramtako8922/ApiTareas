using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static ApiTareas.Services.HolaMundo;

namespace ApiTareas.Controllers

{
    [ApiController]
    [Route ("api/[controller]")]
    public class HolaMundoController : ControllerBase
    {

        IholaService hola;
        TareasContex context;

        public HolaMundoController(IholaService holaw, TareasContex dbcontex)

        {
            hola=holaw;
            context=dbcontex;
            
        }

        
        [HttpGet]
              public IActionResult Hola(){
            return Ok(hola.Hola());
        }
        

         [HttpGet]
        [Route("createdb")]
        public IActionResult createdb(){
            context.Database.EnsureCreated();
            return Ok();
        }
    }
}