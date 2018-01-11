using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TarefaUWP.Data;
using TarefaUWP.Data.Repositorios;
using TarefaUWP.Infraestrutura;
using TarefaUWP.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace TarefaUWP.ViewModel
{
    public class LancamentosVM : NotifyableClass
    {

        public void Initialize()
        {
            using (var context = new Contexto())
            {
                LancamentoRepositorio LancRepo = new LancamentoRepositorio();
                List<Lancamentos> listaLancamentos = LancRepo.CarregarTodos();

                LancamentosReceita = new ObservableCollection<Lancamentos>();
                LancamentosDespesas = new ObservableCollection<Lancamentos>();
                LancamentosBalanco = new ObservableCollection<Balanco>();


                ItensParaCombo = new ObservableCollection<string>();
                ItensParaCombo.Add("Todos");
                listaLancamentos.Where(p => p.Tipo == "R").ToList().ForEach(e => LancamentosReceita.Add(e));
                listaLancamentos.Where(p => p.Tipo == "D").ToList().ForEach(e => LancamentosDespesas.Add(e));

                Balanco bal = new Balanco();
                bal.ValorReceita = LancamentosReceita.Sum(p => p.Valor);
                bal.ValorDespesa = LancamentosDespesas.Sum(p => p.Valor);
                bal.ValorBalanco = bal.ValorReceita - bal.ValorDespesa;
                LancamentosBalanco.Add(bal);

                RetornarListaCombo(listaLancamentos).ForEach(e => ItensParaCombo.Add(e));
            }
        }

        public void Initialize(int mes, int ano)
        {
            using (var context = new Contexto())
            {
                LancamentosReceita.Clear();
                LancamentosDespesas.Clear();
                LancamentosBalanco.Clear();

                LancamentoRepositorio LancRepo = new LancamentoRepositorio();
                List<Lancamentos> listaLancamentos = LancRepo.CarregarTodos();
                if (mes > 0)
                {
                    listaLancamentos.Where(p => p.Tipo == "R" && p.DataLancamento.Month == mes && p.DataLancamento.Year == ano).ToList().ForEach(e => LancamentosReceita.Add(e));
                    listaLancamentos.Where(p => p.Tipo == "D" && p.DataLancamento.Month == mes && p.DataLancamento.Year == ano).ToList().ForEach(e => LancamentosDespesas.Add(e));
                }
                else
                {
                    listaLancamentos.Where(p => p.Tipo == "R").ToList().ForEach(e => LancamentosReceita.Add(e));
                    listaLancamentos.Where(p => p.Tipo == "D").ToList().ForEach(e => LancamentosDespesas.Add(e));
                }
                Balanco bal = new Balanco();
                bal.ValorReceita = LancamentosReceita.Sum(p => p.Valor);
                bal.ValorDespesa = LancamentosDespesas.Sum(p => p.Valor);
                bal.ValorBalanco = bal.ValorReceita - bal.ValorDespesa;
                LancamentosBalanco.Add(bal);

            }
        }

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

        public ObservableCollection<Lancamentos> LancamentosReceita { get; set; }
        public ObservableCollection<Lancamentos> LancamentosDespesas { get; set; }
        public ObservableCollection<Balanco> LancamentosBalanco { get; set; }

        public ObservableCollection<string> ItensParaCombo { get; set; }

        private List<string> RetornarListaCombo(List<Lancamentos> lista)
        {
            var results1 = (from t in lista
                            group t by new { t.DataLancamento.Month, t.DataLancamento.Year } into grp
                            select new
                            {
                                Mes = RecuperarMes(grp.Key.Month),
                                Ano = grp.Key.Year.ToString(),
                            }).ToList();

            List<string> str = new List<string>();

            foreach (var item in results1)
            {
                str.Add(item.Mes + "/" + item.Ano);
            }

            return str;
        }

        private string RecuperarMes(int mes)
        {
            switch (mes)
            {
                case 1: return "Janeiro";
                case 2: return "Fevereiro";
                case 3: return "Março";
                case 4: return "Abril";
                case 5: return "Maio";
                case 6: return "Junho";
                case 7: return "Julho";
                case 8: return "Agosto";
                case 9: return "Setembro";
                case 10: return "Outubro";
                case 11: return "Novembro";
                case 12: return "Dezembro";
                default: return "Inválido";
            }
        }
    }

}
