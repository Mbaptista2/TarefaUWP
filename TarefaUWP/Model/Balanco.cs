using TarefaUWP.Infraestrutura;

namespace TarefaUWP.Model
{
    public class Balanco : NotifyableClass
    {
        private double _valorReceita;

        public double ValorReceita
        {
            get { return _valorReceita; }
            set { Set(ref _valorReceita, value); }
        }
        private double _valorDespesa;

        public double ValorDespesa
        {
            get { return _valorDespesa; }
            set { Set(ref _valorDespesa, value); }
        }
        private double _valorBalanco;

        public double ValorBalanco
        {
            get { return _valorBalanco; }
            set { Set(ref _valorBalanco, value); }
        }
    }
}
