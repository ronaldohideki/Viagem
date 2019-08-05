using Site.Dados;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Services
{
    public class DadosPaginaServices
    {
        private ApplicationDbContext _contexto;
        

        public DadosPaginaServices(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }


        public async void Salvar(DadosPagina dadosPagina)
        {
             _contexto.DadosPaginas.Add(dadosPagina);
            await _contexto.SaveChangesAsync();
            
        }
    }
}
