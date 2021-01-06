using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NewPortalAssiant.Common
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return DoCanExecute?.Invoke(parameter) == true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            DoExecute?.Invoke(parameter);
        }

        public Action<Object> DoExecute { get; set; }
        public Func<object, bool> DoCanExecute { get; set; }
    }
}
