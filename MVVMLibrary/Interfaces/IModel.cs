using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMLibrary
{
   /// <summary>
   /// Add <see cref="PropertyChanged"/> handling to a model.
   /// </summary>
   public interface IModel
   {
      /// <summary>
      /// !! NOT USED !!
      /// <para/>
      /// Event that updates the GUI.
      /// <para/>
      /// Use <see cref="OnPropertyChanged(string)"/> to trigger event.
      /// </summary>
      event PropertyChangedEventHandler PropertyChanged;

      /// <summary>
      /// Triggers the event if able. If name is not provided, will default to the name of the property its called from.
      /// </summary>
      /// <param name="name">Name of the property to provide to the event.</param>
      void OnPropertyChanged([CallerMemberName] string name = null);

      /// <summary>
      /// Triggers the <see cref="PropertyChanged"/> event for multiple names at the same time.
      /// </summary>
      /// <param name="names">Names of properties to update.</param>
      void OnPropertyChanged(params string[] names);
   }
}