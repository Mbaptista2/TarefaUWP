using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefaUWP.Infraestrutura;
using TarefaUWP.Model;

namespace TarefaUWP.ViewModel
{
    public class LancamentosVM: NotifyableClass
    {
        #region Propriedades

        private string _id;
        public string Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }
        private double _valor;

        public double Valor
        {
            get { return _valor; }
            set { Set(ref _valor, value); }
        }
        private string _tipo;

        public string Tipo
        {
            get { return _tipo; }
            set { Set(ref _tipo, value); }
        }
        private DateTime _dataLancamento;

        public DateTime DataLancamento
        {
            get { return _dataLancamento; }
            set { Set(ref _dataLancamento, value); }
        }
        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { Set(ref _descricao, value); }
        }
        #endregion

        public ObservableCollection<Lancamentos> Lancamentos { get; set; } = new ObservableCollection<Lancamentos>();
    }
}
