using System;
using System.Collections.Generic;

namespace Lab3._2ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> menu = new Dictionary<string, double>();
            menu.Add("slice of pizza", 1.99);
            menu.Add("pretzel", 2.49);
            menu.Add("hot dog", 1.49);
            menu.Add("burger", 2.99);
            menu.Add("fries", 2.49);
            menu.Add("candy", 0.99);
            menu.Add("burrito", 3.99);
            menu.Add("fountain drink", 1.99);

            List<string> items = new List<string>();
            List<double> prices = new List<double>();

            bool userWantsToContinue;

            Console.WriteLine("Welcome to Guenther's Market!\n");

            do
            {
                DisplayMenu(menu);

                Console.WriteLine("Which item would you like to order?");

                string selection = Console.ReadLine().ToLower();
                if (menu.ContainsKey(selection) == false)
                {
                    Console.WriteLine("This item isn't available on the menu. Below is our menu!");
                    DisplayMenu(menu);
                }
                else
                {
                    Console.WriteLine($"\nAdding {selection} to cart at {menu[selection]}");
                    items.Add(selection);
                    prices.Add(menu[selection]);
                }


                Console.WriteLine("\nWould you like to continue shopping? (y/n)");
                string userWantsToContinueReply = Console.ReadLine().ToLower();
                Console.Clear();
                if (userWantsToContinueReply == "y")
                {
                    userWantsToContinue = true;
                }
                else
                {
                    userWantsToContinue = false;
                }

            } while (userWantsToContinue == true);

            Console.WriteLine("\nThanks for your order!");
            Console.WriteLine("Here's what you got:");
            double total = 0;
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{items[i]}\t\t{prices[i]}");
                total = total + prices[i];
            }

            double average = total / items.Count;
            average.ToString("0.##");
            Console.WriteLine($"\nThe average price per item in the order was ${average}");
        }
        static void DisplayMenu(Dictionary<string, double> menu)
        {
            Console.WriteLine($"Item\t\t\tPrice");
            Console.WriteLine("==============================");
            foreach (var item in menu)
            {
                Console.WriteLine(String.Format("{0,-15} {1,14}", item.Key, item.Value));
            }
            Console.WriteLine();
        }
    }
}
