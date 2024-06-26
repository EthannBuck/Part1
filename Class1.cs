﻿// Ethan Buck
// ST10250745
// Group 1

// References:
// https://www.geeksforgeeks.org/console-clear-method-in-c-sharp/
// https://raisanenmarkus.github.io/csharp/part3/1/#:~:text=Creating%20a%20new%20list%20is,the%20List%20variable%20is%20List.
// https://wellsb.com/csharp/beginners/create-menu-csharp-console-application

// This section represents a delimiter for clarity
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

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

        // Lists to store ingredient details
        List<string> ingName = new List<string>();
        List<int> ingQuantity = new List<int>();
        List<string> ingUnit = new List<string>();
        List<string> stepDescription = new List<string>();
        List<int> newIngQuantity = new List<int>();

        // Variables to hold recipe details
        string name;
        int quantity;
        string unit;
        int numSteps;
        string description;
        double numScale;
        int newQuantity;
        int numIngredients;
        string clearChoice;
        int choice;

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // Method to display menu options
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

        // Main method to run the recipe program
        public void Run()
        {
            do
            {
                DisplayMenu();
                Console.WriteLine("Enter your choice (1-7): ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
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
                        if (choice == 6)
                        {
                            Console.WriteLine("Are you sure you want to clear all data? (yes/no)");
                            clearChoice = Console.ReadLine().ToLower();

                            if (clearChoice == "yes")
                            {
                                ClearRecipeData();
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7:");
                        break;
                }
            } while (choice != 7);
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // Method to input ingredients
        public void Ingredients()
        {
            Console.WriteLine("Enter the number of ingredients: ");
            try
            {
                numIngredients = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer:");
                return;
            }
            if (numIngredients <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of ingredients:");
                return;
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("Enter the name of the ingredient: ");
                name = Console.ReadLine();
                ingName.Add(name);

                Console.WriteLine("Enter the quantity of the ingredient: ");
                try
                {
                    quantity = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer:");
                    ingName.RemoveAt(ingName.Count - 1);
                    i--;
                    continue;
                }

                if (quantity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the quantity:");
                    ingName.RemoveAt(ingName.Count - 1);
                    i--;
                    continue;
                }

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

        // Method to print original recipe report
        public void PrintReport()
        {
            Console.WriteLine("");
            Console.WriteLine("*************************************************");
            Console.WriteLine("");
            Console.WriteLine("INGREDIENTS FOR RECIPE: ");
            Console.WriteLine("");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine(ingQuantity[i] + " " + ingUnit[i] + " of " + ingName[i]);
            }

            Console.WriteLine("");
            Console.WriteLine("*************************************************");
            Console.WriteLine("");
            Console.WriteLine("STEPS FOR RECIPE: ");
            Console.WriteLine("");

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": " + stepDescription[i]);
            }

            Console.WriteLine("");
            Console.WriteLine("*************************************************");
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // Method to input steps
        public void Steps()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter the number of steps: ");
            try
            {
                numSteps = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer:");
                return;
            }
            if (numSteps <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of steps:");
                return;
            }

            for (int i = 1; i <= numSteps; i++)
            {
                Console.WriteLine("Enter Step " + i);
                description = Console.ReadLine();
                stepDescription.Add(description);
            }
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // Method to change the scale factor
        public void ScaledFactor()
        {
            Console.WriteLine("What would you like to change the scale factor to? '0.5', '2', or '3' : ");
            try
            {
                numScale = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                return;
            }

            for (int i = 0; i < numIngredients; i++)
            {
                if (numScale == 0.5)
                {
                    newQuantity = ingQuantity[i] / 2;
                    newIngQuantity.Add(newQuantity);
                }
                else if (numScale == 2)
                {
                    newQuantity = ingQuantity[i] * 2;
                    newIngQuantity.Add(newQuantity);
                }
                else if (numScale == 3)
                {
                    newQuantity = ingQuantity[i] * 3;
                    newIngQuantity.Add(newQuantity);
                }
            }
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // Method to print updated recipe report
        public void NewPrintReport()
        {
            Console.WriteLine("");
            Console.WriteLine("*************************************************");
            Console.WriteLine("");
            Console.WriteLine("INGREDIENTS FOR RECIPE: ");
            Console.WriteLine("");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine(newIngQuantity[i] + " " + ingUnit[i] + " of " + ingName[i]);
            }

            Console.WriteLine("");
            Console.WriteLine("*************************************************");
            Console.WriteLine("");
            Console.WriteLine("STEPS FOR RECIPE: ");
            Console.WriteLine("");

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": " + stepDescription[i]);
            }

            Console.WriteLine("");
            Console.WriteLine("*************************************************");
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // Method to clear all data from recipe
        public void ClearRecipeData()
        {
            ingName.Clear();
            ingQuantity.Clear();
            ingUnit.Clear();
            stepDescription.Clear();
            newIngQuantity.Clear();

            numIngredients = 0;
            numSteps = 0;
            numScale = 0;

            Console.WriteLine("All recipe data has been cleared. You can now enter a new recipe.");
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*****************************************************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<**********************END OF FILE*****************************>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
