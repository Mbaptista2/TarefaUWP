using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TarefaUWP.Infraestrutura
{
    public abstract class NotifyableClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Set<T>(ref T data, T value, [CallerMemberName]string propertyName = null)
        {
            if (!object.Equals(data, value))
            {
                data = value;
                this.OnPropertyChanged(propertyName);
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private Action _methodToExecute;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action methodToExecute)
        {
            _methodToExecute = methodToExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _methodToExecute.Invoke();
        }
    }
}
