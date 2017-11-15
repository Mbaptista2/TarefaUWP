using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaUWP.Interfaces
{
    interface IRepositorio<T>
    {
        List<T> CarregarTodos();
        T CarregarPorID(int ID);
        void Inserir(T entity);
        void Atualizar(T entity);
        void Excluir(T entity);
    }
}
