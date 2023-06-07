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
        public string? Name
        {
            get; set;
        }
        public double Quantity
        {
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
            get; set;
        }
    }
    class FullRecipes
    {
        public string? Name
        {
            get; set;
        }
        public List<Ingredients>? Ingredient
        {
            get; set;
        }
        public List<Steps>? Step
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
            Console.WriteLine( Name);
            Console.WriteLine("\u001b[4mIngredients\u001b[0m");
            if (Ingredient != null)
            {
                foreach (var ingredients in Ingredient)
                {
                    Console.WriteLine("*" + ingredients.Name + " " + ingredients.Quantity + ingredients.MeasurementUnit);
                }
            }
            if (Step != null) 
            { 
                Console.WriteLine("\u001b[4mSteps:\u001b[0m");
                for (int a = 0; a < Step.Count; a++)
                {
                    Console.WriteLine((a + 1) + "*" + Step[a].Instructions);
                }
            }
        }
        public void Scaling(double number)
        {
            if (Ingredient != null)
            {
                foreach (var ingredients in Ingredient)
                {
                    ingredients.Quantity *= number;
                }
            }
        }
        public void ResetScalledQuantities()
        {
            Console.WriteLine("Quantities are reseted to original value.");
        }
        public void DeleteRecipe()
        {
            if (Ingredient != null)
            {
                Ingredient.Clear();
            }
            if (Step != null)
            {
                Step.Clear();
            }
            Console.WriteLine("The" + Name + "recipe is deleted.");
        }
        public int TotalCalories()
        {
            
            int total = 0;
            foreach (var ingredients in Ingredient!)
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
               
                string? firststep = Console.ReadLine(); //takes in user input for the menu

                if (firststep == "1") // If the user chooses option one then the code under the if statement will be executed
                {
                    FullRecipes recipe = new FullRecipes();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("What is the name of the recipe?");
                    recipe.Name = Console.ReadLine()!;

                    Console.Clear();

                    Console.WriteLine("How many ingredients would you like to enter for the " + recipe.Name + " recipe?");
                    int? size = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    for (int a = 0; a < size; a++) // for loop that stores values into the arrays
                    {
                        Console.WriteLine("Please enter ingredient information");
                        Ingredients ingredient = new Ingredients()!;

                        Console.WriteLine("Please enter the name of the ingredient");
                        ingredient.Name = Console.ReadLine()!; //takes in user input to be stored 
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
                        recipe.Ingredient?.Add(ingredient);
                        Console.Clear();
                        
                    }
                    Console.WriteLine("How many steps would you like to enter?");
                    int number = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("Step" + (i + 1) + ":");
                        Steps steps = new Steps();
                        steps.Instructions = Console.ReadLine()!;
                        recipe.Step?.Add(steps);
                    }
                    recipes.Add(recipe);
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
                        recipes.Sort((re1, re2) => re1.Name.CompareTo(re2.Name));
                        foreach (var recipe in recipes)
                        {
                            Console.WriteLine("*" + recipe.Name);
                        }
                        Console.WriteLine("Which recipe would you like to view?");
                        string? recipeName = Console.ReadLine();

                        FullRecipes viewRecipe = recipes.Find(re => re.Name == recipeName)!;
                        if (viewRecipe != null)
                        {
                            Console.WriteLine();
                            viewRecipe.PrintRecipe();
                            Console.WriteLine();
                            Console.WriteLine("Total number of calories:" + viewRecipe.TotalCalories());

                            viewRecipe.MaxCalories(300);
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
                                    viewRecipe.PrintRecipe();
                                }
                                else if (secondChoice == "2")
                                {
                                    Environment.Exit(0);
                                }
                                else if (secondChoice == "3")
                                {
                                    Console.WriteLine("With which value would you like your recipe to be scaled with?");
                                    double numbertoScale = Convert.ToDouble(Console.ReadLine());
                                    viewRecipe.Scaling(numbertoScale);
                                    Console.WriteLine("Recipe has new quantities.");
                                    viewRecipe.PrintRecipe();
                                }
                                else if (secondChoice == "4")
                                {
                                    viewRecipe.DeleteRecipe();
                                }
                                else
                                {
                                    Console.WriteLine("The chosen option is not available, please try again");
                                }
                            }
                            else
                            {
                                Console.WriteLine("The recipe chosen is not available.");
                            }

                        }
                    }
                }
                else if (firststep== "3") 
                {
                    Environment.Exit(0);
                }
            }
             
        }
    }
}