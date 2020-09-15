using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============================================TASK-1=============================================");
            GameItem itm = new GameItem();
            itm.ItemCount = 10;

            Durak d = new Durak();
            PokerTexas p = new PokerTexas();
            BlackJack b = new BlackJack();

            itm.GiveCards(d);
            Console.WriteLine("\nIn Durak " + itm.ItemCount.ToString() + " cards!");
            itm.GiveCards(p);
            Console.WriteLine("In Poker " + itm.ItemCount.ToString() + " cards!");
            itm.GiveCards(b);
            Console.WriteLine("In BlackJack " + itm.ItemCount.ToString() + " cards!");

            Console.WriteLine("=============================================TASK-2=============================================");

            Algorithm m = new Algorithm();
            m.TemplateMethod(new Wash());
            m.TemplateMethod(new Comb());
            m.TemplateMethod(new Cut());
            m.TemplateMethod(new Drying());

            Console.ReadKey();
        }
    }
}
