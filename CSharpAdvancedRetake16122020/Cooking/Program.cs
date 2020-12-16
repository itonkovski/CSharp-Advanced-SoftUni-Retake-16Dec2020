using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(firstInput);
            Stack<int> ingredients = new Stack<int>(secondInput);

            int breadCounter = 0;
            int cakeCounter = 0;
            int pastryCounter = 0;
            int fruitPieCounter = 0;

            while (liquids.Any() && ingredients.Any())
            {
                int currentLiquid = liquids.Peek();
                int currentIngredient = ingredients.Peek();
                int sumOfCurrents = currentLiquid + currentIngredient;

                if (sumOfCurrents == 25)
                {
                    breadCounter++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sumOfCurrents == 50)
                {
                    cakeCounter++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sumOfCurrents == 75)
                {
                    pastryCounter++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sumOfCurrents == 100)
                {
                    fruitPieCounter++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    ingredients.Push(currentIngredient + 3);
                }
            }

            if (breadCounter >= 1 && cakeCounter >= 1 && fruitPieCounter >= 1 && pastryCounter >= 1)
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine($"Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine($"Ingredients left: none");
            }

            Console.WriteLine($"Bread: {breadCounter}");
            Console.WriteLine($"Cake: {cakeCounter}");
            Console.WriteLine($"Fruit Pie: {fruitPieCounter}");
            Console.WriteLine($"Pastry: {pastryCounter}");
        }
    }
}
