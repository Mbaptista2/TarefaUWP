using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaUWP.Model;

namespace TarefaUWP.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Lancamentos> DBLancamentos { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=lancamentos.db");
        }
    }
}
