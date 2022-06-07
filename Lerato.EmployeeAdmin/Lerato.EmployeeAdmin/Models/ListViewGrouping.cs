using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lerato.EmployeeAdmin.Models
{
    public class ListViewGrouping<K, T> : ObservableCollection<T>
    {
        public K GroupKey { get; private set; }

        public ListViewGrouping(K key, IEnumerable<T> items)
        {
            GroupKey = key;

            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }
    }
}
