using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============================================TASK-1=============================================");
            Creator c = new Creator();
            IProduct product;
            int count = 10;
            Counter counter = Counter.getInstance(count);

            for (int i = 0; i <= count * 2; i++)
            {
                product = c.FactoryMethod();
                Console.WriteLine("You can take:  " + product.Cook());
            }

            Console.WriteLine("=============================================TASK-2=============================================");

            DrinkBuilder latteBuilder = new VanillaLatte();
            Controller auto = new Controller();
            Drink latteDrink = auto.GiveDrink(latteBuilder);
            // Print content
            Console.WriteLine("Your Vanilla Latte:");
            Console.WriteLine("    Base: " + latteDrink.Base);
            Console.WriteLine("    Milk: " + latteDrink.Milk);
            Console.WriteLine("    Sirup: " + latteDrink.Sirup);
            Console.WriteLine("    Suger: " + latteDrink.Sugar);
            Console.WriteLine("    Water: " + latteDrink.Water);
            // Create a Excel report
            DrinkBuilder cocoaBuilder = new Cocoa();
            Drink cocoaDrink = auto.GiveDrink(cocoaBuilder);
            // Print content
            Console.WriteLine("Your Cocoa:");
            Console.WriteLine("    Base: " + cocoaDrink.Base);
            Console.WriteLine("    Milk: " + cocoaDrink.Milk);
            Console.WriteLine("    Sirup: " + cocoaDrink.Sirup);
            Console.WriteLine("    Suger: " + cocoaDrink.Sugar);
            Console.WriteLine("    Water: " + cocoaDrink.Water);

            Console.ReadKey();
        }
    }
}
