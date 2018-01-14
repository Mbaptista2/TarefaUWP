using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaUWP.Interfaces;
using TarefaUWP.Model;

namespace TarefaUWP.Data.Repositorios
{
    public class LancamentoRepositorio : RepositorioBase<Lancamentos>
    {
        private static readonly Lazy<LancamentoRepositorio> _instance =
            new Lazy<LancamentoRepositorio>(() => new LancamentoRepositorio());

        public static LancamentoRepositorio Instance => _instance.Value;
        
        public override void Atualizar(Lancamentos entity)
        {
            using (var context = new Contexto())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public override Lancamentos CarregarPorID(int Id)
        {
            using (var context = new Contexto())
            {
                return context.DBLancamentos.Find(Id);
            }
        }

        public override List<Lancamentos> CarregarTodos()
        {
            using (var context = new Contexto())
            {
                return context.DBLancamentos.AsNoTracking().ToList();
            }
        }

        public override void Excluir(Lancamentos entity)
        {
            using (var context = new Contexto())
            {
                context.DBLancamentos.Remove(entity);
                context.SaveChanges();
            }
        }

        public override void Inserir(Lancamentos entity)
        {
            using (var context = new Contexto())
            {
                context.DBLancamentos.Add(entity);
                context.SaveChanges();
            }
        }       
    }
}
