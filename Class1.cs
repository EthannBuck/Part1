﻿// Ethan Buck
// ST10250745
// Group 1

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROGPOE.Classes
{
    internal class Class1
    {
        List<string> ingName = new List<string>();
        List<int> ingQuantity = new List<int>();
        List<string> ingUnit = new List<string>();
        List<string> stepDescription = new List<string>();
        List<int> newIngQuantity = new List<int>();

        string name;
        int quantity;
        string unit;
        int numSteps;
        string description;
        double numScale;
        int newQuantity;
        int numIngredients;

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public void DisplayMenu()
        {
            Console.WriteLine("************* MENU **************");
            Console.WriteLine("1. Enter Ingredients");
            Console.WriteLine("2. Enter Steps");
            Console.WriteLine("3. Print Original Recipe Report");
            Console.WriteLine("4. Change Scale Factor");
            Console.WriteLine("5. Print Updated Recipe Report");
            Console.WriteLine("6. Clear Recipe Data");
            Console.WriteLine("7. Exit");
            Console.WriteLine("*********************************");
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public void Run()
        {
            int choice;
            do
            {
                DisplayMenu();
                Console.WriteLine("Enter your choice (1-7): ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Ingredients();
                        break;
                    case 2:
                        Steps();
                        break;
                    case 3:
                        PrintReport();
                        break;
                    case 4:
                        ScaledFactor();
                        break;
                    case 5:
                        NewPrintReport();
                        break;
                    case 6:
                        ClearRecipeData();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        break;
                }
            } while (choice != 7);
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public void Ingredients()
        {
            Console.WriteLine("Enter the number of ingredients: ");
            numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("Enter the name of the ingredient: ");
                name = Console.ReadLine();
                ingName.Add(name);

                Console.WriteLine("Enter the quantity of the ingredient: ");
                quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the unit of measurement of the ingredient: ");
                unit = Console.ReadLine();

                if (unit.ToLower() == "tablespoons")
                {
                    if (quantity % 16 == 0)
                    {
                        quantity /= 16;
                    }
                    else
                    {
                        quantity = quantity / 16 + 1;
                    }
                    unit = "cups";
                }
                ingQuantity.Add(quantity);
                ingUnit.Add(unit);
            }
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    }
}
