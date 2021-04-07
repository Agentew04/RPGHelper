using System;
using System.Windows.Input;

namespace Ficha
{
    public class RelayCommand : ICommand
    {
#pragma warning disable IDE0044
#pragma warning disable CS0067
        private Action _act;
#pragma warning restore IDE0044
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action act)
        {
            this._act = act;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _act();
        }
    }
    public class RelayCommand<T> : ICommand
    {
#pragma warning disable IDE0044
        private Action<T> _act;
#pragma warning restore IDE0044
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> act)
        {
            this._act = act;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _act((T)parameter);
        }
    }
}
