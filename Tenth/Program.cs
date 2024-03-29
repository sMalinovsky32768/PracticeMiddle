﻿using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace Tenth
{
    public class Program
    {
        public static List<Price> Prices { get; set; } = new();

        public static void Main()
        {
            ForegroundColor = ConsoleColor.White;
            FillList();

            while (true)
            {
                Write("Press 1 to view the product list in shop or 2 to view the product list in all shop or any other key to exit");
                var keyInfo = ReadKey();
                WriteLine();

                if (keyInfo.KeyChar == '1')
                {
                    try
                    {
                        DisplayProductsInShop();
                    }
                    catch (ShopNotFoundException ex)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine(ex.Message);
                        ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (keyInfo.KeyChar == '2')
                {
                    DisplayProducts();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Заполняет список товаров с клавиатуры
        /// </summary>
        private static void FillList()
        {
            while (true)
            {
                Write("Enter count of products: ");
                if (int.TryParse(ReadLine(), out var count))
                {
                    for (var i = 0; i < count; i++)
                    {
                        NewProduct(i);
                    }

                    break;
                }
                else
                {
                    WriteLine("Invalid count");
                }
            }
        }

        /// <summary>
        /// Добавляет новый товар
        /// </summary>
        private static void NewProduct(int i)
        {
            WriteLine($"\tProdfuct {i + 1}");
            while (true)
            {
                Write("\t\tEnter product name: ");
                var productName = ReadLine();

                Write("\t\tEnter shop name: ");
                var shopName = ReadLine();

                decimal cost;
                while (true)
                {
                    Write("\t\tEnter product cost: ");
                    if (decimal.TryParse(ReadLine(), out cost))
                    {
                        break;
                    }

                    WriteLine("\t\tInvalid cost");
                }

                Prices.Add(new Price { ProductName = productName, Cost = cost, ShopName = shopName });

                break;
            }
        }

        /// <summary>
        /// Выводит список товара из определенного магазина.
        /// </summary>
        /// <exception cref="ShopNotFoundException">Магазин не найден</exception>
        private static void DisplayProductsInShop()
        {
            Write("\nEnter shop name: ");
            var shopName = ReadLine();
            var productsInShop = Prices.Where(p => p.ShopName == shopName).OrderBy(p => p.ProductName);
            if (productsInShop.Any())
            {
                foreach (var product in productsInShop)
                {
                    WriteLine($"{nameof(Price.ShopName)}: {product.ShopName};\t{nameof(Price.ProductName)}: {product.ProductName};\t{nameof(Price.Cost)}: {product.Cost};");
                }

                return;
            }

            throw new ShopNotFoundException(shopName);
        }

        /// <summary>
        /// Выводит список товаров
        /// </summary>
        private static void DisplayProducts()
        {
            foreach (var product in Prices.OrderBy(p => p.ShopName).ThenBy(p => p.ProductName))
            {
                WriteLine($"{nameof(Price.ShopName)}: {product.ShopName};\t{nameof(Price.ProductName)}: {product.ProductName};\t{nameof(Price.Cost)}: {product.Cost};");
            }
        }
    }
}
