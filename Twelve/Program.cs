using System.Linq;

using static System.Console;

OutputEncoding = System.Text.Encoding.Unicode;

var dictionary = new[]
{
   new { Eng = "Dog", Rus = "Собака" },
   new { Eng = "Cat", Rus = "Кот" },
   new { Eng = "String", Rus = "Строка" },
   new { Eng = "Word", Rus = "Слово" },
   new { Eng = "Collection", Rus = "Коллекция" },
   new { Eng = "System", Rus = "Система" },
   new { Eng = "Generic", Rus = "Общий" },
   new { Eng = "Console", Rus = "Консоль" },
   new { Eng = "USA", Rus = "США" },
};

WriteLine("Anonymous");
foreach(var item in dictionary)
{
    WriteLine($"{item.Eng} - {item.Rus}");
}
WriteLine();

var dynamicDictionary = dictionary.Select(x => x as dynamic).ToArray();

WriteLine("Dynamic");
foreach (var item in dynamicDictionary)
{
    WriteLine($"{item.Eng} - {item.Rus}");
}