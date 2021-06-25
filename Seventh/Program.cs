using Seventh;

using static System.Console;

var myList = new MyList<int>() { 6, 8, 7, 8, 10 };

var array = myList.GetArray();

foreach (var item in array)
{
    WriteLine(item);
}