using ApiSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboSite.Dados
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DadosPagina> DadosPaginas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server = LAPTOP - KQRIL123\\SQLEXPRESS; Database = Ef_Estudo; User = Id = sa; Password = 123; Trusted_Connection = True; ");

            optionsBuilder.UseSqlServer("Server=LAPTOP-KQRIL123\\SQLEXPRESS; Database = Ef_Estudo; User = Id = sa; Password = 123; Trusted_Connection = True; ");
        }

    }
}
