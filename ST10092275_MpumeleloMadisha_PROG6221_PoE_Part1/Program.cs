﻿using System;
using System.Drawing;
using System.Timers;

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
                Console.Clear();
            }
            for (int b = 0; b < size; b++)
            {
                Console.WriteLine("Please enter the quantity of ingredient");
                array[b] = Console.ReadLine();
                Console.Clear();
            }
            for (int c = 0; c < size; c++)
            {
                Console.WriteLine("Please enter the measurement unit of ingredient");
                array[c] = Console.ReadLine();
                Console.Clear();
            }
        }


        static void NoSteps()
        {
            Console.WriteLine("How many steps would you like to enter?");

            int number = Convert.ToInt32(Console.ReadLine());
            string[] arr = new string[number];
            Console.Clear();
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Please enter the name of the ingredient");
                arr[i] = Console.ReadLine();
                Console.Clear();
            }
        }
        public static void Main(string[] args)
        {
            Console.Title = "PROG6221_PART1";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("********************************************************************");
            Console.WriteLine("Welcome to Sanele's recipe app");
            Console.WriteLine("Press enter to proceed ;-)");
            Console.WriteLine("********************************************************************");
            
            
            
            Console.ResetColor();

            RecipeName myObj = new RecipeName();
            Console.WriteLine("What is the name of the recipe?");
            myObj.Name = Convert.ToString(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("How many ingredients would you like to enter for the " + myObj.Name + " recipe?");
            Console.Clear();

            NoIngredients();
            NoSteps();
            
            Console.Read();
        }


    }
}
