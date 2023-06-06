using System;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace RecipeConsole
{
    class Ingredients
    {
        public string Name
        {
            get; set;
        }
        public double Quantity
        {
            get; set;
        }
        public string MeasurementUnit
        {
            get; set;
        }
        public int Calories
        {
            get; set;
        }
        public int FoodGroup
        {
            get; set;
        }
    }
    class Steps
    {
        public string Instructions
        {
            get; set;
        }
    }
    class FullRecipes
    {
        public string Name
        {
            get; set;
        }
        public List<Ingredients> Ingredient
        {
            get; set;
        }
        public List<Steps> Step
        {
            get; set;
        }
        public FullRecipes()
        {
            Ingredient = new List<Ingredients>();
            Step = new List<Steps>();
        }

        public void PrintRecipe()
        {
            Console.WriteLine("Here is the recipe for:");
            Console.WriteLine("/t" + Name);
            Console.WriteLine("\u001b[4mIngredients\u001b[0m");

            foreach (var ingredients in Ingredient)
            {
                Console.WriteLine("*" + ingredients.Name + " " + ingredients.Quantity + ingredients.MeasurementUnit);
            }
            Console.WriteLine("\u001b[4mSteps:\u001b[0m");
            for (int a = 0; a < Step.Count; a++)
            {
                Console.WriteLine((a + 1) + "*" + Step[a].Instructions);
            }
        }
        public void Scaling(double number)
        {
            foreach (var ingredients in Ingredient)
            {
                ingredients.Quantity *= number;
            }
        }
        public void ResetScalledQuantities()
        {
            Console.WriteLine("Quantities are reseted to original value.");
        }
        public void DeleteRecipe()
        {
            Ingredient.Clear();
            Step.Clear();
            Console.WriteLine("The" + Name + "Recipe is deleted.");
        }
        public int TotalCalories()
        {
            int total = 0;
            foreach (var ingredients in Ingredient)
            {
                total += ingredients.Calories;
            }
            return total;
        }
        public void MaxCalories(int max)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int total = TotalCalories();
            if (total > max)
            {
                Console.WriteLine("            Warning!");
                Console.WriteLine("Maximum calories in a recipe are exceeded, this recipe might not be good for you." + max);
            }
            Console.ResetColor();
        }
    }
    class RecipeApp //declares a class
    {
        static void Main(string[] args) // declares main method
        {
            List<FullRecipes> recipes = new List<FullRecipes>();
            while (true)
            {
                Console.Title = "PROG6221_PART2"; //Names the console application
                Console.ForegroundColor = ConsoleColor.Magenta; //Changes the colour of the text to Magenta
                Console.BackgroundColor = ConsoleColor.White;// Changes background text to black
                Console.WriteLine("********************************************************************");
                Console.WriteLine("                Welcome to Sanele's recipe app  ");                       //Welcomes user to the applications
                Console.WriteLine("********************************************************************");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1) Add Recipe");  //Displays a menu to user
                Console.WriteLine("2) Display all Recipes");
                Console.WriteLine("3) Exit Application");
                Console.ResetColor();
                Recipes(); // Calls the EditRecipe method
                Console.ReadKey(); //Executes commands within the code more efficiently

                string firststep = Console.ReadLine(); //takes in user input for the menu

                if (firststep == "1") // If the user chooses option one then the code under the if statement will be executed
                {
                    RecipeApp recipe = new RecipeApp();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("What is the name of the recipe?");
                    recipes.Name = Console.ReadLine();
                    
                    Console.Clear();

                    Console.WriteLine("How many ingredients would you like to enter for the " + myObj.Name + " recipe?");
                    int? size = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                }
            }
            static void Recipes() //Declares a new method
            {
                int? firststep = Convert.ToInt32(Console.ReadLine()); //takes in user input for the menu

                if (firststep == 1) // If the user chooses option one then the code under the if statement will be executed
                {
                    for (int k = 0; k < recipes; k++)
                    {
                        

                        Console.WriteLine("How many ingredients would you like to enter for the " + myObj.Name + " recipe?");


                        int? size = Convert.ToInt32(Console.ReadLine());


                        for (int a = 0; a < size; a++) // for loop that stores values into the arrays
                        {
                            Console.WriteLine("Please enter the name of the ingredient");
                            string ingredient = Console.ReadLine()!; //takes in user input to be stored 
                            list.Add(ingredient);

                            Console.Clear();
                            Console.WriteLine("Please enter the quantity of ingredient");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            list.Add(list[quantity]);

                            Console.Clear(); // clears the application output and user input to remove clutter

                            Console.WriteLine("Please enter the measurement unit of ingredient ");
                            string unit = Console.ReadLine()!;
                            list.Add(unit);
                            Console.Clear();

                            Console.WriteLine("Please enter the number calories of ingredient");
                            int calories = Convert.ToInt32(Console.ReadLine());
                            list.Add(list[calories]);
                            Console.Clear();

                            Console.WriteLine("Please enter the food group of ingredient");
                            string foodGroup = Console.ReadLine()!;
                            list.Add(foodGroup);

                            Console.Clear();
                            Console.WriteLine("Please enter any key to proceed");
                            Console.Clear();
                        }
                        Console.WriteLine("How many steps would you like to enter?");
                        int number = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < number; i++)
                        {
                            Console.Write("-");
                            string step = Console.ReadLine()!;
                            list.Add(step);

                        }
                    }
                    bool valid = false; //ensures that user inputs correct input if not, it will reboot the code
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
                            bool end = false; //checks if user input is correct
                            while (!end)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("********************************************************************");
                                Console.WriteLine("                          Main Menu");
                                Console.WriteLine("********************************************************************");
                                Console.WriteLine("1) Display Recipe");                                                          //Displays the main menu
                                Console.WriteLine("2) Exit Application");
                                Console.WriteLine("3) Change Recipe quantities");
                                Console.WriteLine("4) Clear Recipe");
                                Console.ResetColor();
                                int step = Convert.ToInt32(Console.ReadLine());
                                if (step == 1) // when user selects option 1, the code under this if statement will be executed
                                {
                                    Console.WriteLine("Here is the recipe for " + myObj.Name);
                                    Console.WriteLine("********************************************************************"); //Prints the recipe for option 1
                                    Console.WriteLine("");
                                    Console.WriteLine("                  \u001b[4mIngredients\u001b[0m"); //underlines the name ingredients
                                    for (int x = 0; x < size; x++)
                                    {

                                    }
                                    Console.WriteLine("");
                                    Console.WriteLine("                  \u001b[4mInstructions\u001b[0m");
                                    for (int x = 0; x < size; x++)
                                    {
                                        Console.WriteLine(x + 1 + ". " + arr[x]);
                                    }
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("1) Exit Application");
                                    Console.WriteLine("2) Change Recipe quantities");
                                    Console.WriteLine("3) Clear Recipe");
                                    Console.ResetColor();
                                    int? enter = Convert.ToInt32(Console.ReadLine()); //the "?" allows the variable to be null
                                    if (enter == 1)
                                    {
                                        Environment.Exit(0); //Exits the application
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
                                                    Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x] + " --> " + (ar[x] * 0.5) + " " + array2[x] + " " + array[x]); //displays the recipe
                                                }
                                                Console.WriteLine("Do you wish to save these values Y/N");
                                                string? selection = Console.ReadLine();
                                                if (selection!.Equals("Y")) //the "!" allows the string to be null
                                                {
                                                    for (int x = 0; x < size; x++) //for loop to store the new recipe that has changed quantities
                                                    {
                                                        ar[x] = (ar[x] * 0.5);  // for loop to multiply by 0.5
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
                                                    Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x] + " --> " + (ar[x] * 2) + " " + array2[x] + " " + array[x]); //shows the values multiplied my 2
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
                                                    //resets code
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
                                        Array.Clear(arr, 0, arr.Length); //clears all the user input from arrays and leaves the arrays empty
                                        Array.Clear(array, 0, array.Length);
                                        Array.Clear(array2, 0, array.Length);
                                        Console.WriteLine("Delete successfull");
                                        Console.ReadLine(); // takes input for when menu is called again
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong input"); // displays an error and displays menu again
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
                                    Console.WriteLine("Please press enter to proceed");

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
                        else if (input == 2)
                        {
                            Environment.Exit(0);
                            valid = true;
                        }
                        else
                        {

                        }
                    }
                }
                else if (firststep == 2)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("invalid selection"); //writes an error message
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }
    }
}