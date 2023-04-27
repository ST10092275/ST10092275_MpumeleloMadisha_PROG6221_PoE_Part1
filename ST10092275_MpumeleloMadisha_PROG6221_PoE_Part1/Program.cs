using System;
using System.Drawing;
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
        static void NoIngredients()
        {

            int size = Convert.ToInt32(Console.ReadLine());
            string[] array = new string[size];

            for (int a = 0; a < size; a++)
            {
                Console.WriteLine("Please enter the name of the ingredient");
                array[a] = Console.ReadLine();
            }
            Console.Clear();
            for (int b = 0; b < size; b++)
            {
                Console.WriteLine("Please enter the quantity of ingredient");
                array[b] = Console.ReadLine();
            }
            Console.Clear();
            for (int c = 0; c < size; c++)
            {
                Console.WriteLine("Please enter the measurement unit of ingredient");
                array[c] = Console.ReadLine();
            }
            Console.Clear();
        }
        static void NoSteps()
        {
            Console.WriteLine("How many steps would you like to enter?");

            int number = Convert.ToInt32(Console.ReadLine());
            string[] arr = new string[number];

            for (int i = 0; i < number; i++)
            {
                Console.Write("-");
                arr[i] = Console.ReadLine();

            }
        }
        static void AddRecipe()
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
               

                NoIngredients();
                Console.WriteLine("Please enter any key to proceed");
                Console.Clear();
                NoSteps();
                Console.Clear();

                Console.WriteLine("Select an option");
                Console.WriteLine("1) Main Menu.");
                Console.WriteLine("2) Exit Application.");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("********************************************************************");
                Console.WriteLine("                          Main Menu");
                Console.WriteLine("********************************************************************");
                Console.WriteLine("1) Print Recipe");
                Console.WriteLine("2) Exit Application.");
                Console.ResetColor();

                int step = Convert.ToInt32(Console.ReadLine());

                if (step == 1)
                {

                    Console.WriteLine("Here is the recipe for " + myObj);
                    Console.WriteLine("********************************************************************");

                }

            }
            if (firststep == 2)
            {
                Console.ReadKey(true);
                Environment.Exit(0);

            }
            Console.Read();
        }
        public static void Main(string[] args)
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
