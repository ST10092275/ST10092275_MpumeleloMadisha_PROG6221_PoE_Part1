﻿using System;
using System.Drawing;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace recipes
{
    class RecipeName
    {
        private string name = Console.ReadLine();
        public string Name
        {
            get { return name; }
            set { name = value; }

        }
    }
    class Recipe
    {

        static void AddRecipe(int a)
        {
            int firststep = Convert.ToInt32(Console.ReadLine());

            if (firststep == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please press any key to proceed");
                Console.ResetColor();


                RecipeName myObj = new RecipeName();
                Console.WriteLine("What is the name of the recipe?");
                myObj.Name = Convert.ToString(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("How many ingredients would you like to enter for the " + myObj.Name + " recipe?");


                int size = Convert.ToInt32(Console.ReadLine());
                string[] array = new string[size];
                double[] ar = new double[size];
                string[] array2 = new string[size];

                for (int a = 0; a < size; a++)
                {
                    Console.WriteLine("Please enter the name of the ingredient");
                    array[a] = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Please enter the quantity of ingredient");
                    ar[a] = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("Please enter the measurement unit of ingredient ");
                    array2[a] = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Please enter any key to proceed");
                    Console.Clear();
                }
                    Console.WriteLine("How many steps would you like to enter?");
                    int number = Convert.ToInt32(Console.ReadLine());
                    string[] arr = new string[number];
                    for (int i = 0; i < number; i++)
                    {
                        Console.Write("-");
                        arr[i] = Console.ReadLine();

                    }
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Select an option");
                    Console.WriteLine("1) Main Menu.");
                    Console.WriteLine("2) Exit Application.");
                    Console.ResetColor();

                    int input = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (input == 1)
                    {

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("********************************************************************");
                        Console.WriteLine("                          Main Menu");
                        Console.WriteLine("********************************************************************");
                        Console.WriteLine("1) Display Recipe");
                        Console.WriteLine("2) Exit Application");
                        Console.WriteLine("3) Change Recipe quantities");
                        Console.WriteLine("4) Clear Recipe");
                        Console.ResetColor();
                        

                        int step = Convert.ToInt32(Console.ReadLine());

                        if (step == 1)
                        {

                            Console.WriteLine("Here is the recipe for " + myObj.Name);
                            Console.WriteLine("********************************************************************");
                            Console.WriteLine("");
                            Console.WriteLine("                  \u001b[4mIngredients\u001b[0m");

                            Console.WriteLine(ar[a] + " " + array2[a] + " " + array[a]);
                           
                            Console.WriteLine(" ");
                            Console.WriteLine("                  \u001b[4mInstructions\u001b[0m");
                            foreach (string element in arr)
                            {
                                Console.Write(element);
                            }
                        
                    }
                        if (step == 2)
                    {
                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }
                        if (step == 3)
                    {
                        Console.WriteLine("With which value do you want multiply quantities?");
                        double multiply = Convert.ToDouble(Console.ReadLine());

                        double z = ar[a] *= multiply;
                        Console.Clear();

                        
                            Console.WriteLine("Here is the recipe for " + myObj.Name);
                            Console.WriteLine("********************************************************************");
                            Console.WriteLine("");
                            Console.WriteLine("                  \u001b[4mIngredients\u001b[0m");

                            Console.WriteLine(z + " " + array2[a] + " " + array[a]);
                           
                            Console.WriteLine(" ");
                            Console.WriteLine("                  \u001b[4mInstructions\u001b[0m");
                            foreach (string element in arr)
                            {
                                Console.Write(element);
                            }

                    }
                    }
                    if (input == 2)
                    {
                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }

            }
                if (firststep == 2)
                {
                    Console.ReadKey(true);
                    Environment.Exit(0);

                }
                Console.Read();
        
        }

            static void Main(string[] args)
            {
                Console.Title = "PROG6221_PART1";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("********************************************************************");
                Console.WriteLine("                Welcome to Sanele's recipe app  ");
                Console.WriteLine("********************************************************************");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1) Add Recipe");
                Console.WriteLine("2) Exit Application");
                Console.ResetColor();

                AddRecipe();

            }


    }
}
