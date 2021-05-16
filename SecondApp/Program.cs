using Second;

using System;
using System.IO;

namespace SecondApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 0 for open exist file or other for create new: ");
            var isNew = Console.ReadLine() != "0";

            string fileName = ReadFileName(args, isNew);

            var doc = AbstractHandler.CreateInstance(fileName);

            var type = doc switch
            {
                XMLHandler => "xml",
                DOCHandler => "doc",
                _ => "txt",
            };

            doc.Open();
            doc.Save();

            Console.WriteLine($"Type of file'{fileName}' is {type}");

            _ = Console.ReadKey();
        }

        private static string ReadFileName(string[] args, bool isNew)
        {
            if (args.Length > 0 && File.Exists(args[0]))
            {
                return args[0];
            }
            else
            {
                while (true)
                {
                    Console.Write("Enter name of file: ");
                    var fileName = Console.ReadLine();
                    if (isNew || File.Exists(fileName))
                    {
                        return fileName;
                    }
                    else
                    {
                        Console.WriteLine($"File '{fileName}' doesn't exist");
                    }
                }
            }
        }
    }
}
