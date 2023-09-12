using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_15
{
  public  class Exercise15
    {
        private static void OnCollectionchanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                if (e.NewItems?[0] is int newnumber)
                    Console.WriteLine($"Element {newnumber} is added in collection");
            if (e.Action == NotifyCollectionChangedAction.Remove)
                if (e.OldItems?[0] is int oldnumber)
                    Console.WriteLine($"Element {oldnumber} is removed from collection");
        }
        public Exercise15()
        {
            ObservableCollection<int> numbers = new ObservableCollection<int>();
            numbers.Add(1);
            numbers.CollectionChanged += OnCollectionchanged;
            numbers.Add(5);
            numbers.Add(10);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.RemoveAt(0);
            numbers.RemoveAt(0);
            numbers.RemoveAt(0);
            numbers.RemoveAt(0);
            numbers.RemoveAt(0);
        }
    }
}
