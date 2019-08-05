using ApiSite.Models;
using RoboSite.Dados;

namespace RoboSite.Services
{
    public class DadosPaginaServices
    {
        private ApplicationDbContext _contexto;

        public DadosPaginaServices(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        public void Salvar(DadosPagina dadosPagina)
        {
            _contexto.DadosPaginas.Add(dadosPagina);
            _contexto.SaveChanges();
        }
    }
}
