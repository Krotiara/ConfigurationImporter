using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationImporter.Model
{
    public static class Extensions
    {
        public static void AddRange<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> collection)
        {
            foreach (var i in collection)
                observableCollection.Add(i);
        }
    }
}
