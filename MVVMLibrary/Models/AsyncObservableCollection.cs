using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVVMLibrary.Models
{
   /// <summary>
   /// Customized version of the <see cref="ObservableCollection{T}"/> class that can allow different threads to change the collection.
   /// <para/>
   /// Using the original class will throw an exception when trying to change something from another thread. Also, what counts as a different thread is more than just <see cref="Task.Run(Action)"/>.
   /// Things like <see cref="Timer"/> callbacks will also count as a different thread.
   /// </summary>
   public class AsyncObservableCollection<T> : ObservableCollection<T>
   {
      private SynchronizationContext _synchronizationContext = SynchronizationContext.Current;

      /// <inheritdoc/>
      public AsyncObservableCollection() { }

      /// <inheritdoc/>
      public AsyncObservableCollection(IEnumerable<T> list)
          : base(list) { }

      /// <inheritdoc/>
      protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
      {
         if (SynchronizationContext.Current == _synchronizationContext)
         {
            // Execute the CollectionChanged event on the current thread
            RaiseCollectionChanged(e);
         }
         else
         {
            // Raises the CollectionChanged event on the creator thread
            _synchronizationContext.Send(RaiseCollectionChanged, e);
         }
      }

      private void RaiseCollectionChanged(object param)
      {
         // We are in the creator thread, call the base implementation directly
         base.OnCollectionChanged((NotifyCollectionChangedEventArgs)param);
      }

      /// <inheritdoc/>
      protected override void OnPropertyChanged(PropertyChangedEventArgs e)
      {
         if (SynchronizationContext.Current == _synchronizationContext)
         {
            // Execute the PropertyChanged event on the current thread
            RaisePropertyChanged(e);
         }
         else
         {
            // Raises the PropertyChanged event on the creator thread
            _synchronizationContext.Send(RaisePropertyChanged, e);
         }
      }

      private void RaisePropertyChanged(object param)
      {
         // We are in the creator thread, call the base implementation directly
         base.OnPropertyChanged((PropertyChangedEventArgs)param);
      }
   }
}
