using System;
using System.Linq;
using System.Security.Cryptography;

using static System.Console;

Func<Func<int>[], int> func = delegate (Func<int>[] funcs)
 {
     var sun = funcs?.Sum(f => f?.Invoke() ?? 0) ?? 0;
     return sun is 0 ? 0 : sun / funcs.Length;
 };

Write("Enter count of numbers (default 10): ");
int count;
if (!int.TryParse(ReadLine(), out count)) count = 10;

Func<int>[] funcs = new Func<int>[count];
for (var i = 0; i < count; i++)
{
    funcs[i] = () => RandomNumberGenerator.GetInt32(int.MaxValue / count);
}

WriteLine($"Result: {func.Invoke(funcs)}");