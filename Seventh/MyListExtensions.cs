using System.Linq;

namespace Seventh
{
    public static class MyListExtensions
    {
        public static T[] GetArray<T>(this MyList<T> list) => list.ToArray();
    }
}
