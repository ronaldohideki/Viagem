using ApiSite.Models;
using ApiSite.Services;
using RoboSite.Dados;
using RoboSite.Services;
using System;

namespace RoboSite
{
    class Program
    {
        static void Main(string[] args)
        {
            FilaServices fila = new FilaServices("FilaSite");
            //var resultado = fila.RetrieveSingleMessage();
            //DadosPagina dadosPagina = new DadosPagina { Ip = "192.68", Navegador = "Chrome", NomePagina = "Default" };

            DadosPagina dadosPagina;

            do
            {
               dadosPagina = fila.ReturnMessage();

                if (dadosPagina != null)
                {
                    var incluirService = new IncluirServices(dadosPagina);
                    incluirService.IncluirNoBanco();
                    incluirService.IncluirNoArquivo();
                }

            } while (dadosPagina != null);
           
            Console.WriteLine("Sucesso");
            Console.ReadLine();
        }
    }
}
