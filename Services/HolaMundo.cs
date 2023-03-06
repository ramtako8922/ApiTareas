using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ApiTareas.Services.HolaMundo;

namespace ApiTareas.Services
{
    public class HolaMundo : IholaService
    {
        public string Hola(){

            return "hola mundo";
        }

        public interface IholaService{
           string Hola();
        }
    }
}