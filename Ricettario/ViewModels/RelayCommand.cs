using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ricettario.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> executeMethod;
        private Predicate<object> canExecuteMethod;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> Execute) : this(Execute, null)
        {

        }
        public RelayCommand(Action<object> Execute, Predicate<object> CanExecute)
        {
            executeMethod = Execute;
            canExecuteMethod = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (canExecuteMethod == null) ? true : canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
