using System;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;//allows uage of delegates

namespace RecipeConsole
{
    class Ingredients //new class created
    {
        public string? Name //? used to make Name nullable
        {
            get; set;
        }
        public double Quantity
        {                                            //using getters and setters to represent ingredients inforomation
            get; set;
        }
        public string? MeasurementUnit
        {
            get; set;
        }
        public int Calories
        {
            get; set;
        }
        public string? FoodGroup
        {
            get; set;
        }
    }
    class Steps
    {
        public string? Instructions
        {
            get; set; // uses getters and setters to represent instruction for the steps
        }
    }
    class FullRecipes
    {
        public string? Name
        {
            get; set;
        }
        public List<Ingredients>? Ingredient //list created to store ingredients
        {
            get; set;
        }
        public List<Steps>? Step  //list created to store steps
        {
            get; set;
        }
        public FullRecipes()
        {
            Ingredient = new List<Ingredients>();
            Step = new List<Steps>();
        }

        public void PrintRecipe() //print recipe method created, to print the recipe
        {
            Console.WriteLine("Here is the recipe for:");
            Console.WriteLine(Name);
            Console.WriteLine("\u001b[4mIngredients\u001b[0m"); // underlined the word ingredients
            if (Ingredient != null)
            {
                foreach (var ingredients in Ingredient)
                {
                    Console.WriteLine("*" + ingredients.Name + " " + ingredients.Quantity + ingredients.MeasurementUnit); //Prints all recipe ingredients and their information
                }
            }
            if (Step != null)
            {
                Console.WriteLine("\u001b[4mSteps:\u001b[0m");
                for (int a = 0; a < Step.Count; a++)
                {
                    Console.WriteLine((a + 1) + "*" + Step[a].Instructions); //for loop to print step while addind numbers to each step
                }
            }
        }
        public void Scaling(double number) //method to scale quatity 
        {
            if (Ingredient != null)
            {
                foreach (var ingredients in Ingredient)
                {
                    ingredients.Quantity *= number; //calculates the quantities with the number inputted
                }
            }
        }
        public void ResetScalledQuantities()
        {
            Console.WriteLine("Quantities are reseted to original value."); //resets quantity values
        }
        public void DeleteRecipe()
        {
            if (Ingredient != null) // makes ingredient nullable
            {
                Ingredient.Clear();//Deletes ingredients in therecipe chosen
            }
            if (Step != null)
            {
                Step.Clear(); //deletes steps in a recipe
            }
            Console.WriteLine("The" + Name + "recipe is deleted.");
        }
        public int TotalCalories()
        {

            int total = 0;
            foreach (var ingredients in Ingredient!)
            {
                total += ingredients.Calories; //calculates number of calories
            }
            return total; //returns the total number calculated
        }
        public void MaxCalories(int max)
        {
            Console.ForegroundColor = ConsoleColor.Red; //makes the waring red
            int total = TotalCalories();
            if (total > max) //comapres the total to the max of 300 to see if calories are exceeded
            {
                Console.WriteLine("Warning!");
                Console.WriteLine("Maximum calories in a recipe are exceeded, this recipe might not be good for you." + max);
            }
            Console.ResetColor();
        }
    }
    class RecipeApp //declares a class
    {
        static void Main(string[] args) // declares main method
        {
            List<FullRecipes> recipes = new List<FullRecipes>(); //New list created
            while (true)
            {
                Console.Title = "PROG6221_PART2"; //Names the console application
                Console.ForegroundColor = ConsoleColor.Magenta; //Changes the colour of the text to Magenta
                Console.BackgroundColor = ConsoleColor.White;// Changes background text to black
                Console.WriteLine("********************************************************************");
                Console.WriteLine("                Welcome to Sanele's recipe app  ");                       //Welcomes user to the applications
                Console.WriteLine("********************************************************************");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("1) Add Recipe");  //Displays a menu to user
                Console.WriteLine("2) Display all Recipes");
                Console.WriteLine("3) Exit Application");
                Console.ResetColor(); //resets colour of the program

                string? firststep = Console.ReadLine(); //takes in user input for the menu

                if (firststep == "1") // If the user chooses option one then the code under the if statement will be executed
                {
                    FullRecipes recipe = new FullRecipes();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("What is the name of the recipe?");
                    recipe.Name = Console.ReadLine()!;

                    Console.Clear(); //clears previous output and input

                    Console.WriteLine("How many ingredients would you like to enter for the " + recipe.Name + " recipe?");
                    int? size = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    for (int a = 0; a < size; a++) // for loop that stores values into the arrays
                    {
                        Console.WriteLine("Please enter ingredient information");
                        Ingredients ingredient = new Ingredients()!; //exclamation used to make the new delegate nullable
                                                                     //creates new ingredient
                        Console.WriteLine("Please enter the name of the ingredient");
                        ingredient.Name = Console.ReadLine()!; //takes in user input to be stored using a delegate
                        Console.Clear();

                        Console.WriteLine("Please enter the quantity of ingredient");
                        ingredient.Quantity = Convert.ToDouble(Console.ReadLine());
                        Console.Clear(); // clears the application output and user input to remove clutter

                        Console.WriteLine("Please enter the measurement unit of ingredient ");
                        ingredient.MeasurementUnit = Console.ReadLine()!;
                        Console.Clear();

                        Console.WriteLine("Please enter the number calories of ingredient");
                        ingredient.Calories = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Please enter the food group of ingredient");

                        ingredient.FoodGroup = Console.ReadLine()!;
                        recipe.Ingredient?.Add(ingredient); //addsthe ingredients to the recipe
                        Console.Clear();

                    }
                    Console.WriteLine("How many steps would you like to enter?");
                    int number = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("Step" + (i + 1) + ":");//numbers the steps
                        Steps steps = new Steps();
                        steps.Instructions = Console.ReadLine()!;
                        recipe.Step?.Add(steps); //adds the steps to the recipe
                    }
                    recipes.Add(recipe); //adds the recipe
                    Console.ResetColor();
                }
                else if (firststep == "2")
                {
                    if (recipes.Count == 0)
                    {
                        Console.WriteLine("The Recipe is invalid");
                    }
                    else
                    {
                        Console.WriteLine("\u001b[4mRecipes:\u001b[0m");
                        recipes.Sort((re1, re2) => re1.Name.CompareTo(re2.Name)); //makes the recipes to show in alphabetical order
                        foreach (var recipe in recipes)
                        {
                            Console.WriteLine("*" + recipe.Name);
                        }
                        Console.WriteLine("Which recipe would you like to view?");
                        string? recipeName = Console.ReadLine();
                        Console.Clear();

                        FullRecipes viewRecipe = recipes.Find(re => re.Name == recipeName)!; //chooses the recipe to view
                        if (viewRecipe != null)
                        {
                            Console.WriteLine();
                            viewRecipe.PrintRecipe(); //displays the recipe chosen
                            Console.WriteLine();
                            Console.WriteLine("Total number of calories:" + viewRecipe.TotalCalories());

                            viewRecipe.MaxCalories(300); //limits the maximum calories to 300
                            Console.Clear();
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Select an option");
                            Console.WriteLine("1) Main Menu.");
                            Console.WriteLine("2) Exit Application.");
                            Console.ResetColor();
                            string? choice = Console.ReadLine();

                            if (choice == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("********************************************************************");
                                Console.WriteLine("                          Main Menu");
                                Console.WriteLine("********************************************************************");
                                Console.WriteLine("1) Display Recipe");                                                          //Displays the main menu
                                Console.WriteLine("2) Exit Application");
                                Console.WriteLine("3) Change Recipe quantities");
                                Console.WriteLine("4) Clear Recipe");
                                string? secondChoice = Console.ReadLine();
                                Console.ResetColor();
                                Console.Clear();

                                if (secondChoice == "1")
                                {
                                    viewRecipe.PrintRecipe(); // prints recipe
                                }
                                else if (secondChoice == "2")
                                {
                                    Environment.Exit(0); //exists the application
                                }
                                else if (secondChoice == "3")
                                {
                                    Console.WriteLine("Are you sure you want to scale the recipe? Enter Y or N");//asks user if they really want to change quantities
                                    string? answer = Console.ReadLine();
                                    if (answer == "Y")
                                    {
                                        Console.WriteLine("With which value would you like your recipe to be scaled with?");
                                        double numbertoScale = Convert.ToDouble(Console.ReadLine());
                                        viewRecipe.Scaling(numbertoScale); // changes quantities of the recipe to the number chosen/inputted
                                        Console.WriteLine("Recipe has new quantities.");
                                        viewRecipe.PrintRecipe(); //views newly scaled recipe
                                        Console.Clear();
                                    }
                                    else if (answer == "N")
                                    {
                                        Console.WriteLine("");
                                        Console.Clear();
                                    }
                                }
                                else if (secondChoice == "4")
                                {
                                    viewRecipe.DeleteRecipe(); //detes the recipe using a methosd
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("The chosen option is not available, please try again");
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("The recipe chosen is not available.");
                                Console.Clear();
                            }

                        }
                    }
                }
                else if (firststep == "3")
                {
                    Environment.Exit(0); //exists application
                }
            }

        }
    }
}
