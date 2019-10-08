using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace System.Linq
{
    public static class ObservableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>(source);
            return collection;
        }

        public static ObservableRangeCollection<T> ToObservableRangeCollection<T>(this IEnumerable<T> source)
        {
            ObservableRangeCollection<T> collection = new ObservableRangeCollection<T>(source);
            return collection;
        }

    }
}
