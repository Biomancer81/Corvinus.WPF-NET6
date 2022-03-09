using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Corvinus.WPF.Common.Extensions
{
    /// <summary>
    /// An ObservableCollection Class Extensions.
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// RefreshWith allows you to supply an IEnumerable collection of items and replace
        /// the existing items in the ObservableCollection.
        /// </summary>
        /// <typeparam name="T">TypeOf T.</typeparam>
        /// <param name="collection">ObservableCollection.</param>
        /// <param name="items">IEnumerable.</param>
        public static void RefreshWith<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null)
            {
                collection = new ObservableCollection<T>();
            }

            if (collection.Count > 0)
            {
                collection.Clear();
            }

            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}
