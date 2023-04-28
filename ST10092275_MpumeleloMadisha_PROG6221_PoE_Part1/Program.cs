using System;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Reflection;
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
            get { return name!; }
            set { name = value; }

        }
    }
    class Recipe
    {
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

            EditRecipe();
            Console.ReadKey();

        }
        static void EditRecipe()
        {
            int? firststep = Convert.ToInt32(Console.ReadLine());

            if (firststep == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please press enter to proceed");
                Console.ResetColor();

                RecipeName myObj = new();
                Console.WriteLine("What is the name of the recipe?");
                myObj.Name = Convert.ToString(Console.ReadLine()!);
                Console.Clear();

                Console.WriteLine("How many ingredients would you like to enter for the " + myObj.Name + " recipe?");


                int size = Convert.ToInt32(Console.ReadLine());
                string[] array = new string[size];//ingrediants name
                double[] ar = new double[size];//quantity
                string[] array2 = new string[size];//measurements


                for (int a = 0; a < size; a++)
                {
                    Console.WriteLine("Please enter the name of the ingredient");
                    array[a] = Console.ReadLine()!;

                    Console.Clear();
                    Console.WriteLine("Please enter the quantity of ingredient");
                    ar[a] = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("Please enter the measurement unit of ingredient ");
                    array2[a] = Console.ReadLine()!;

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
                //Console.WriteLine(select);
                //Console.WriteLine(input);
                //Console.ReadLine();
                bool valid = false;
                while (!valid)
                {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Select an option");
                Console.WriteLine("1) Main Menu.");
                Console.WriteLine("2) Exit Application.");
                Console.ResetColor();

                int? input = Convert.ToInt32(Console.ReadLine());
                    if (input == 1)
                    {
                    bool end = false;
                    while (!end)
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
                        int counter = 1;
                        while (counter < step)
                        {
                            counter++;
                        }
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
                            Console.WriteLine("{0}. {1}", counter, element);
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("1) Exit Application");
                        Console.WriteLine("2) Change Recipe quantities");
                        Console.WriteLine("3) Clear Recipe");
                        Console.ResetColor();
                        int? enter = Convert.ToInt32(Console.ReadLine());
                        if (enter == 1)
                        {
                            Environment.Exit(0);
                        }
                        else if (enter == 2)
                        {
                            Console.WriteLine("Are you sure you want to change quantities?");
                            Console.WriteLine("Enter Y/N");
                            string? answer = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine(answer);
                            Console.ReadLine();
                            if (answer == "Y")
                            {
                                
                                Console.WriteLine("With which value do you want multiply quantities?");
                                Console.WriteLine("1) 0.5");
                                Console.WriteLine("2) 2");
                                Console.WriteLine("3) 3");
                                int? z = Convert.ToInt32(Console.ReadLine());
                                        if (z == 1)
                                        {
                                            Console.WriteLine("Here is the recipe for " + myObj.Name);
                                            Console.WriteLine("********************************************************************");
                                            Console.WriteLine("");
                                            Console.WriteLine("                  \u001b[4mIngredients\u001b[0m\n");

                                            for (int x = 0; x < size; x++)
                                            {
                                                Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x] + " --> " + (ar[x] / 2) + " " + array2[x] + " " + array[x]);
                                            }
                                            Console.WriteLine("Do you wish to save these values Y/N");
                                            string? selection = Console.ReadLine();
                                            if (selection!.Equals("Y"))
                                            {
                                                for (int x = 0; x < size; x++)
                                                {
                                                    ar[x] = (ar[x] / 2);
                                                }
                                            }
                                            else if (selection!.Equals("N"))
                                            {

                                            }
                                            else
                                            {

                                            }

                                        }
                                        else if (z == 2)
                                        {
                                            Console.WriteLine("Here is the recipe for " + myObj.Name);
                                            Console.WriteLine("********************************************************************");
                                            Console.WriteLine("");
                                            Console.WriteLine("                  \u001b[4mIngredients\u001b[0m\n");

                                            for (int x = 0; x < size; x++)
                                            {
                                                Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x] + " --> " + (ar[x] * 2) + " " + array2[x] + " " + array[x]);
                                            }
                                            Console.WriteLine("Do you wish to save these values Y/N");
                                            string? selection = Console.ReadLine();
                                            if (selection!.Equals("Y"))
                                            {
                                                for (int x = 0; x < size; x++)
                                                {
                                                    ar[x] = (ar[x] * 2);
                                                }
                                            }
                                            else if (selection!.Equals("N"))
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                        else if (z == 3)
                                        {
                                            Console.WriteLine("Here is the recipe for " + myObj.Name);
                                            Console.WriteLine("********************************************************************");
                                            Console.WriteLine("");
                                            Console.WriteLine("                  \u001b[4mIngredients\u001b[0m\n");

                                            for (int x = 0; x < size; x++)
                                            {
                                                Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x] + " --> " + (ar[x] * 3) + " " + array2[x] + " " + array[x]);
                                            }
                                            Console.WriteLine("Do you wish to save these values Y/N");
                                            string? selection = Console.ReadLine();
                                            if (selection!.Equals("Y"))
                                            {
                                                for (int x = 0; x < size; x++)
                                                {
                                                    ar[x] = (ar[x] * 3);
                                                }
                                            }
                                            else if (selection!.Equals("N"))
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                        }
                            else if (answer == "N")
                            {
                                Console.WriteLine("Closing Application");
                                Console.ReadKey(true);
                                Environment.Exit(0);

                            } 
                        }
                        else if (enter == 3)
                        {
                            Array.Clear(ar, 0, ar.Length);
                            Array.Clear(arr, 0, arr.Length);
                            Array.Clear(array, 0, array.Length);
                            Array.Clear(array2, 0, array.Length);
                            Console.WriteLine("Delete successfull");
                                    Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                                    Console.ReadLine();
                                }
                    }
                    else if (step == 2)
                    {
                                end = true;
                        Environment.Exit(0);
                    }
                    else if (step == 3)
                    {
                        Console.WriteLine("Are you sure you want to change quantities?");
                        Console.WriteLine("Enter Y/N");
                        string? answer = Console.ReadLine();
                        
                        if (answer!.Equals("Y"))
                        {
                            Console.Clear();
                            Console.WriteLine("With which value do you want multiply quantities?");
                            Console.WriteLine("1) 0.5");
                            Console.WriteLine("2) 2");
                            Console.WriteLine("3) 3");
                            int z = Convert.ToInt32(Console.ReadLine());
                            if (z == 1)
                            {

                                Console.WriteLine("Here is the recipe for " + myObj.Name);
                                Console.WriteLine("********************************************************************");
                                Console.WriteLine("");
                                Console.WriteLine("                  \u001b[4mIngredients\u001b[0m\n");

                                for (int x = 0; x < size; x++)
                                {
                                    Console.WriteLine(x+1+". " + ar[x] +" " + array2[x]+" " + array[x] +" --> "+(ar[x]/2) + " " + array2[x] + " " + array[x]);
                                }
                                Console.WriteLine("Do you wish to save these values Y/N");
                                string? selection = Console.ReadLine();
                                if (selection!.Equals("Y"))
                                {
                                    for (int x = 0; x < size; x++)
                                    {
                                        ar[x] = (ar[x] / 2);
                                    }
                                }
                                else if (selection!.Equals("N"))
                                {

                                }
                                else
                                {

                                }
                                
                                if (z == 2)
                                        { 
                                            Console.WriteLine("Here is the recipe for " + myObj.Name);
                                            Console.WriteLine("********************************************************************");
                                            Console.WriteLine("");
                                            Console.WriteLine("                  \u001b[4mIngredients\u001b[0m\n");

                                            for (int x = 0; x < size; x++)
                                            {
                                                Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x] + " --> " + (ar[x] * 2) + " " + array2[x] + " " + array[x]);
                                            }
                                            Console.WriteLine("Do you wish to save these values Y/N");
                                            selection = Console.ReadLine();
                                            if (selection!.Equals("Y"))
                                            {
                                                for (int x = 0; x < size; x++)
                                                {
                                                    ar[x] = (ar[x] *2);
                                                }
                                            }
                                            else if (selection!.Equals("N"))
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                if (z == 3)
                                {
                                            Console.WriteLine("Here is the recipe for " + myObj.Name);
                                            Console.WriteLine("********************************************************************");
                                            Console.WriteLine("");
                                            Console.WriteLine("                  \u001b[4mIngredients\u001b[0m\n");

                                            for (int x = 0; x < size; x++)
                                            {
                                                Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x] + " --> " + (ar[x] * 3) + " " + array2[x] + " " + array[x]);
                                            }
                                            Console.WriteLine("Do you wish to save these values Y/N");
                                            selection = Console.ReadLine();
                                            if (selection!.Equals("Y"))
                                            {
                                                for (int x = 0; x < size; x++)
                                                {
                                                    ar[x] = (ar[x] * 3);
                                                }
                                            }
                                            else if (selection!.Equals("N"))
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                            }
                        }
                        else if (answer.Equals("N"))
                        {
                            Console.WriteLine("Closing Application");
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
                    }
                    else
                    {
                        Console.WriteLine("Incorrect selection");
                        Console.ReadLine();
                    }
                            Console.WriteLine("Invalid selection");
                            Console.ReadLine();
                    } 
                }
                else if(input == 2)
                {
                    Environment.Exit(0);
                    valid = true;
                }
                else
                {

                }
                } 
            }
        }
    }
}
