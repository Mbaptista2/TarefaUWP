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

        Contexto context = new Contexto();
        public override void Atualizar(Lancamentos entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public override Lancamentos CarregarPorID(int ID)
        {
            return context.Set<Lancamentos>().Find(ID);
        }

        public override List<Lancamentos> CarregarTodos()
        {
            return context.Set<Lancamentos>().ToList();
        }

        public override void Excluir(Lancamentos entity)
        {
            context.Set<Lancamentos>().Remove(entity);
            context.SaveChanges();
        }

        public override void Inserir(Lancamentos entity)
        {
            context.DBLancamentos.Add(entity);
            context.SaveChanges();
        }       
    }
}
