using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TotalCalories;

namespace TotalCalories
{
    [TestClass]
    public class FullRecipes
    {

        [TestMethod]

        public void Test_TotalCalories()
        {
            int total = 0;
            foreach (var ingredients in Ingredient)
            {
                total += ingredients.Calories;
            }
            return total;
        }
    }
}
