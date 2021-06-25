using static System.Console;
using System.Security.Cryptography;
using System.Threading;

namespace Ninth
{
    internal class Program
    {
        public static void Main()
        {
            WriteLine("Hello World!");
            Method();
            WriteLine("Goodbuy World!");
        }

        public static void Method()
        {
            WriteLine(RandomNumberGenerator.GetInt32(int.MaxValue));
            new Thread(new ThreadStart(Method)).Start();
        }
    }
}
