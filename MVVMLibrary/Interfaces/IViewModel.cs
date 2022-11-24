using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMLibrary
{
   /// <summary>
   /// ONLY used for view models.
   /// Used to diferentiate between <see cref="IModel"/>s.
   /// Not mutch to add right now. Further expansion needs to be able to be applied to ALL <see cref="ViewModel"/>s.
   /// </summary>
   public interface IViewModel : IModel { }
}
