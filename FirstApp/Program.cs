using First;

using System;

var flag = false;
while (!flag)
{
    Console.Write("Enter number of points (3-5): ");
    if (int.TryParse(Console.ReadLine(), out var n))
    {
        if (n < 3)
        {
            Console.WriteLine("Number of points must be greater than 3");
            continue;
        }
        else if (n > 5)
        {
            Console.WriteLine("Number of points must be less than 5");
            continue;
        }

        flag = true;
        var points = new Point[n];
        for (var i = 0; i < n; i++)
        {
            Console.WriteLine($"Point {i}:");
            points[i] = ReadPoint();
        }

        Figure figure = n switch
        {
            3 => new(points[0], points[1], points[2]),
            4 => new(points[0], points[1], points[2], points[3]),
            5 => new(points[0], points[1], points[2], points[3], points[4]),
            _ => throw new NotImplementedException(),
        };

        Console.WriteLine($"Name of figure: {figure.Name}");
        Console.WriteLine($"Perimiter of figure: {figure.Perimeter()}");
    }
    else
    {
        Console.WriteLine("Number is invalid");
    }
}

static Point ReadPoint()
{
    int? x = null;
    int? y = null;
    while (true)
    {
        if (!x.HasValue)
        {
            Console.Write("\tEnter X: ");
            if (int.TryParse(Console.ReadLine(), out var n))
            {
                x = n;
            }
            else
            {
                Console.WriteLine("X is invalid");
                continue;
            }
        }

        if (!y.HasValue)
        {
            Console.Write("\tEnter Y: ");
            if (int.TryParse(Console.ReadLine(), out var n))
            {
                y = n;
            }
            else
            {
                Console.WriteLine("Y is invalid");
                continue;
            }
        }

        return new(x.Value, y.Value);
    }
}