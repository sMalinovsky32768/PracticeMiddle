using System.Collections;
using System.Collections.Generic;

namespace Seventh
{
    public class MyList<T> : IEnumerable<T>
    {
        public List<T> List { get; set; } = new();
        public int Count => List.Count;

        public void Add(T item) => List.Add(item);

        public IEnumerator<T> GetEnumerator() => List.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => List.GetEnumerator();

        public T this[int index] => List[index];
    }
}
