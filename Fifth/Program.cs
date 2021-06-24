using Fifth;

using System.Reflection;

using static System.Console;

foreach (var method in typeof(Calculator).GetTypeInfo().DeclaredMethods)
    WriteLine(method.Name);