using System;
using System.Windows.Input;

namespace MVVMLibrary
{
    public class Command : ICommand
    {
        public Action<object> ExecuteDelegate { get; private set; }
        public event EventHandler CanExecuteChanged = null;

        public Command() { }

        public Command(Action<object> _ExecuteDelegate) => ExecuteDelegate = _ExecuteDelegate;
        public Command(Action _executeDelegate)
        {
            ExecuteDelegate = (o) => _executeDelegate();
        }

        public bool CanExecute(object param) => true;

        public void Execute(object _oParameter) => ExecuteDelegate?.Invoke(_oParameter);
    }
}
