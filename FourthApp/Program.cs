using Fourth;

using System;

using static System.Console;

Store store = new(
    new("product1", "shop", 666),
    new("product2", "shop", 666),
    new("product3", "shop", 666),
    new("product4", "shop", 666));

while (true)
{
    Write("Press Esc for exit, 1 for search by index or press other for search by product name: ");
    var keyInfo = ReadKey();
    WriteLine();

    if (keyInfo.Key is ConsoleKey.Escape)
    {
        break;
    }
    else if (keyInfo.KeyChar is '1')
    {
        var flag = true;

        while (flag)
        {
            Write($"Enter index (integer): ");

            if (int.TryParse(ReadLine(), out var index))
            {
                flag = false;

                if (store[index] is Article article)
                {
                    WriteLine($"Index: {index};\t{nameof(Article.ProductName)}: {article.ProductName};\t{nameof(Article.ShopName)}: {article.ShopName};\t{nameof(Article.Cost)}: {article.Cost};");
                }
                else
                {
                    WriteLine($"Article with index = {index} not found");
                }
            }
            else
            {
                WriteLine("Invalid index");
            }
        }
    }
    else
    {
        Write($"Enter name of article: ");
        var name = ReadLine();

        if (store[name] is Article article)
        {
            WriteLine($"{nameof(Article.ProductName)}: {article.ProductName};\t{nameof(Article.ShopName)}: {article.ShopName};\t{nameof(Article.Cost)}: {article.Cost};");
        }
        else
        {
            WriteLine($"Article with name = \"{name}\" not found");
        }
    }

    WriteLine();
}