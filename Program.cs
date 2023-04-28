using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace recipes
{
    class RecipeName
    {
        private string? name = Console.ReadLine();
        public string Name
        {
            get { return name; }
            set { name = value; }

        }
    }
    class Recipe
    {

        static void EditRecipe()
        {
            int firststep = Convert.ToInt32(Console.ReadLine());

            if (firststep == 1)
            {
                static void AddRecipe(int a)
                {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please press enter to proceed");
                Console.ResetColor();


                RecipeName myObj = new();
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
                        Console.Clear();


                        int step = Convert.ToInt32(Console.ReadLine());

                        if (step == 1)
                        {

                            Console.WriteLine("Here is the recipe for " + myObj.Name);
                            Console.WriteLine("********************************************************************");
                            Console.WriteLine("");
                            Console.WriteLine("                  \u001b[4mIngredients\u001b[0m");
                            int counter = 1;

                            foreach (double element in ar)
                            {
                                Console.WriteLine("{0}. {1}", counter, element);
                            }
                            foreach (string element in array2)
                            {
                                Console.WriteLine("{0}. {1}", counter, element);
                            }
                            foreach (string element in array)
                            {
                                Console.WriteLine("{0}. {1}", counter, element);
                            }
                            Console.WriteLine(" ");
                            Console.WriteLine("                  \u001b[4mInstructions\u001b[0m");
                            foreach (string element in arr)
                            {
                                Console.WriteLine("{0}. {1}",counter, element);
                            }
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("1) Exit Application");
                            Console.WriteLine("2) Change Recipe quantities");
                            Console.WriteLine("3) Clear Recipe");
                            Console.ResetColor();


                            int enter = Convert.ToInt32(Console.ReadLine());

                            if (enter == 1)
                            {
                                Console.ReadKey(true);
                                Environment.Exit(0);
                            }
                            else if (enter == 2)
                            {

                            }
                            else if (enter == 3)
                            {

                            }
                            else
                            {
                                Console.WriteLine("Wrong input");
                            }
                        }
                        else if (step == 2)
                        {
                            Console.ReadKey(true);
                            Environment.Exit(0);
                        }
                        else if (step == 3)
                        {
                            Console.WriteLine("With which value do you want multiply quantities?");
                            Console.WriteLine("1) 0.5");
                            Console.WriteLine("2) 2");
                            Console.WriteLine("3) 3");

                            int z = Convert.ToInt32(Console.ReadLine());
                            double half = 0.5;
                            int twice = 2;
                            int triple = 3;
                            if (z == 1)
                            {

                                foreach (double num in ar)
                                {
                                    half *= num;
                                }

                                Console.WriteLine("Here is the recipe for " + myObj.Name);
                                Console.WriteLine("********************************************************************");
                                Console.WriteLine("");
                                Console.WriteLine("                  \u001b[4mIngredients\u001b[0m");

                                Console.WriteLine(half + " " + array2[a] + " " + array[a]);

                                Console.WriteLine(" ");
                                Console.WriteLine("                  \u001b[4mInstructions\u001b[0m");
                                foreach (string element in arr)
                                {
                                    Console.Write(element);
                                }
                            }
                            if (z == 2)
                            {

                                foreach (int num in ar)
                                {
                                    twice *= num;
                                }

                                Console.WriteLine("Here is the recipe for " + myObj.Name);
                                Console.WriteLine("********************************************************************");
                                Console.WriteLine("");
                                Console.WriteLine("                  \u001b[4mIngredients\u001b[0m");

                                Console.WriteLine(twice + " " + array2[a] + " " + array[a]);

                                Console.WriteLine(" ");
                                Console.WriteLine("                  \u001b[4mInstructions\u001b[0m");
                                foreach (string element in arr)
                                {
                                    Console.Write(element);
                                }
                            }
                            if ((z == 3))
                            {

                                foreach (int num in ar)
                                {
                                    triple *= num;
                                }

                                Console.WriteLine("Here is the recipe for " + myObj.Name);
                                Console.WriteLine("********************************************************************");
                                Console.WriteLine("");
                                Console.WriteLine("                  \u001b[4mIngredients\u001b[0m");

                                Console.WriteLine(triple + " " + array2[a] + " " + array[a]);

                                Console.WriteLine(" ");
                                Console.WriteLine("                  \u001b[4mInstructions\u001b[0m");
                                foreach (string element in arr)
                                {
                                    Console.Write(element);
                                }
                            }
                            else
                            {
                                Console.ReadKey(true);
                                Environment.Exit(0);
                            }
                        }
                        else if (step == 4)
                        {
                            Array.Clear(ar, 0, ar.Length);
                            Array.Clear(arr, 0, arr.Length);
                            Array.Clear(array, 0, array.Length);
                            Array.Clear(array2, 0, array2.Length);

                            Console.WriteLine("Recipe has been cleared");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("1) Add Recipe");
                            Console.WriteLine("2) Exit Application");
                            Console.WriteLine("3) Display Recipe");
                            Console.ResetColor();

                            int option = Convert.ToInt32(Console.ReadLine());

                            if (option == 1)
                            {

                            }
                        }

                        if (input == 2)
                        {
                            Console.ReadKey(true);
                            Environment.Exit(0);
                        }
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

        private static void AddRecipe()
        {
            throw new NotImplementedException();
        }
    }
}
