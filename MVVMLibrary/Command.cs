using System;
using System.Windows.Input;

namespace MVVMLibrary
{
   /// <summary>
   /// When bound to the Command property on a user control, will trigger an action in a <see cref="ViewModel"/>.
   /// Command binding for triggering an action when a command
   /// </summary>
   public class Command : ICommand
   {
      /// <summary>
      /// The action to perform when the command is executed.
      /// </summary>
      public Action<object>? ExecuteDelegate { get; private set; }
      /// <summary>
      /// !!Not Used!!
      /// <para/>
      /// Will update the <see cref="ViewModel"/> when the Command can be triggered?
      /// </summary>
      public event EventHandler? CanExecuteChanged = null!;

      /// <summary>
      /// !!Not Used!!
      /// <para/>
      /// Need to look into removing if possible.
      /// </summary>
      public Command() { }

      /// <summary>
      /// Create a new <see cref="Command"/> and connect the delegate.
      /// </summary>
      /// <param name="executeDelegate">Delegate to trigger when the command is activated.</param>
      public Command(Action<object> executeDelegate) => ExecuteDelegate = executeDelegate;

      /// <summary>
      /// Create a new <see cref="Command"/> and connect the delegate.
      /// <para/>
      /// Allows for the <see cref="object"/> parameter to be discarded if not used.
      /// </summary>
      /// <param name="executeDelegate">Delegate to trigger when the command is activated.</param>
      public Command(Action executeDelegate) => ExecuteDelegate = (o) => executeDelegate();

      /// <summary>
      /// !!Not Used!!
      /// <para/>
      /// Confirms if the <see cref="Command"/> can be triggered.
      /// </summary>
      /// <param name="param">Optional parameter to be passed to the delegate.</param>
      /// <returns>True if able to execute.</returns>
      public bool CanExecute(object? param) => true;

      /// <summary>
      /// Executes the delegate.
      /// </summary>
      /// <param name="parameter">Optional parameter to be passed to the delegate.</param>
      public void Execute(object? parameter) => ExecuteDelegate?.Invoke(parameter ?? new object());
   }
}
