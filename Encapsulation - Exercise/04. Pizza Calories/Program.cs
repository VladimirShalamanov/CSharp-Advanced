using System;
using System.Linq;

namespace P04PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] p = Console.ReadLine().Split(' ').ToArray();
            Pizza pizza = null;
            try
            {
                pizza = new Pizza(p[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string[] doughArr = Console.ReadLine().Split(' ').ToArray();
            try
            {
                Dough dough = new Dough(doughArr[1], doughArr[2], double.Parse(doughArr[3]));
                pizza.Dough = dough;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] ingredients = cmd.Split(' ').ToArray();

                try
                {
                    Topping topping = new Topping(ingredients[1], double.Parse(ingredients[2]));
                    pizza.AddTopping(topping);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            try
            {
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
