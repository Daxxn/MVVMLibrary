using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMLibrary
{
   public interface IModel
   {
      event PropertyChangedEventHandler PropertyChanged;

      void OnPropertyChanged([CallerMemberName] string name = null);
      void OnPropertyChanged(params string[] names);
   }
}