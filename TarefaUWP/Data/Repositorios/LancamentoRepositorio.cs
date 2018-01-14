﻿using Microsoft.EntityFrameworkCore;
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

            //List<Lancamentos> lista = new List<Lancamentos>();

            //for (int i = 0; i < 3; i++)
            //{
            //    Lancamentos lanc = new Lancamentos();
            //    lanc.Descricao = "Teste";
            //    lanc.Valor = 100.50;
            //    lanc.DataLancamento = new DateTime(2017, 02 + i, 01).Date;
            //    lanc.Tipo = "R";
            //    lista.Add(lanc);
            //}
            //for (int i = 0; i < 20; i++)
            //{
            //    Lancamentos lanc = new Lancamentos();
            //    lanc.Descricao = "Teste Despesa";
            //    lanc.Valor = 45;
            //    lanc.DataLancamento = new DateTime(2017, 02 , 01).Date;
            //    lanc.Tipo = "D";
            //    lista.Add(lanc);
            //}
            //return lista;
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
