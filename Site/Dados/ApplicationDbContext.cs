using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Dados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<DadosPagina> DadosPaginas { get; set; }


    }
}
