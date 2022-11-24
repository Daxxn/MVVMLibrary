using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMLibrary
{
   public class Model : INotifyPropertyChanged, IModel
   {
      public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

      public void OnPropertyChanged([CallerMemberName] string name = null)
      {
         if (!String.IsNullOrEmpty(name))
         {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
         }
      }

      public void OnPropertyChanged(params string[] names)
      {
         foreach (var name in names)
         {
            if (!String.IsNullOrEmpty(name))
            {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
         }
      }
   }
}
