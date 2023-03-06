using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTareas.Middlewares
{
    public class ShowTime
    {
        readonly RequestDelegate next;

        public ShowTime(RequestDelegate requestNext)

        {
            next=requestNext;
            
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context){

            await next(context);

            if (context.Request.Query.Any(p=>p.Key=="time")
            )
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }

        }
    }

    public static class TimeShowExtension{

        public static IApplicationBuilder UseTimeMiddlware(this IApplicationBuilder builder1){

            return builder1.UseMiddleware<ShowTime>();

        }
    }
}