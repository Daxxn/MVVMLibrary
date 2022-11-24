using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMLibrary
{
   /// <summary>
   /// Add <see cref="PropertyChanged"/> handling to a model.
   /// </summary>
   public class Model : INotifyPropertyChanged, IModel
   {
      /// <summary>
      /// !! NOT USED !!
      /// <para/>
      /// Event that updates the GUI.
      /// <para/>
      /// Use <see cref="OnPropertyChanged(string?)"/> to trigger event.
      /// </summary>
      public event PropertyChangedEventHandler? PropertyChanged = (s, e) => { };

      /// <summary>
      /// Triggers the event if able. If name is not provided, will default to the name of the property its called from.
      /// </summary>
      /// <param name="name">Name of the property to provide to the event.</param>
      public void OnPropertyChanged([CallerMemberName] string? name = null)
      {
         if (!string.IsNullOrEmpty(name))
         {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
         }
      }

      /// <summary>
      /// Triggers the <see cref="PropertyChanged"/> event for multiple names at the same time.
      /// </summary>
      /// <param name="names">Names of properties to update.</param>
      public void OnPropertyChanged(params string[] names)
      {
         foreach (var name in names)
         {
            if (!string.IsNullOrEmpty(name))
            {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
         }
      }
   }
}
