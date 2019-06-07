using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MangoLogin
{
	class LoginCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;
		private Action<object> _action;
		/// <summary>
		/// The below constructor of command class is used to create an instance of a delegate using this 
		/// delegate can be associated with any method and can take the advantage of ICommand interface
		/// </summary>
		/// <param name="action">Delegate that can refer to any method</param>
		public LoginCommand(Action<object> action)
		{
			_action = action;
		}
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if (parameter != null)
				_action(parameter);
			else
				_action(null);
		}
	}
}
