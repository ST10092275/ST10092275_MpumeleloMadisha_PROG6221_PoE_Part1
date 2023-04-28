using System;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            get { return name!; }  //Using getters and setters to get the name string o it may be turned into an object
            set { name = value; }

        }
    }
    class Recipe //declares a class
    {
        static void Main(string[] args) // declares main method
        {
            Console.Title = "PROG6221_PART1"; //Names the console application
            Console.ForegroundColor = ConsoleColor.Magenta; //Changes the colour of the text to Magenta
            Console.BackgroundColor = ConsoleColor.White;// Changes background text to black
            Console.WriteLine("********************************************************************");
            Console.WriteLine("                Welcome to Sanele's recipe app  ");                       //Welcomes user to the applications
            Console.WriteLine("********************************************************************");
            Console.ResetColor(); //Resets the background and foreground colour

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1) Add Recipe");  //Displays a menu to user
            Console.WriteLine("2) Exit Application");
            Console.ResetColor();

            EditRecipe(); // Calls the EditRecipe method
            Console.ReadKey(); //Executes commands within the code more efficiently

        }
        static void EditRecipe() //Declares a new method
        {
            int? firststep = Convert.ToInt32(Console.ReadLine()); //takes in user input for the menu

            if (firststep == 1) // If the user chooses option one then the code under the if statement will be executed
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please press enter to proceed"); // prompts user to press enter
                Console.ResetColor();

                RecipeName myObj = new(); //creates a new option that stores recipe name
                Console.WriteLine("What is the name of the recipe?");
                myObj.Name = Convert.ToString(Console.ReadLine()!);
                Console.Clear(); 

                Console.WriteLine("How many ingredients would you like to enter for the " + myObj.Name + " recipe?");


                int size = Convert.ToInt32(Console.ReadLine()); 
                string[] array = new string[size];//declares an array for ingrediants name to store values
                double[] ar = new double[size];//declares an array for quantity to store values
                string[] array2 = new string[size];//declares an array for measurements to store values


                for (int a = 0; a < size; a++) // for loop that stores values into the arrays
                {
                    Console.WriteLine("Please enter the name of the ingredient");
                    array[a] = Console.ReadLine()!; //takes in user input to be stored in an array

                    Console.Clear();
                    Console.WriteLine("Please enter the quantity of ingredient");
                    ar[a] = Convert.ToInt32(Console.ReadLine());

                    Console.Clear(); // clears the application output and user input to remove clutter

                    Console.WriteLine("Please enter the measurement unit of ingredient ");
                    array2[a] = Console.ReadLine()!;

                    Console.Clear();
                    Console.WriteLine("Please enter any key to proceed");
                    Console.Clear();
                }
                Console.WriteLine("How many steps would you like to enter?");
                int number = Convert.ToInt32(Console.ReadLine());
                string[] arr = new string[number]; //declares an array instructions method for to store values
                for (int i = 0; i < number; i++)
                {
                    Console.Write("-");
                    arr[i] = Console.ReadLine()!;

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
                             Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x]);
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
                                                Console.WriteLine(x + 1 + ". " + ar[x] + " " + array2[x] + " " + array[x] + " --> " + (ar[x] * 0.5 ) + " " + array2[x] + " " + array[x]); //displays the recipe
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
            else if(firststep == 2)
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
