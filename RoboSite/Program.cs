using ApiSite.Services;
using System;

namespace RoboSite
{
    class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila("FilaSite");
            //var resultado = fila.RetrieveSingleMessage();
            var dadosPagina = fila.ReturnMessage();

        }
    }
}
