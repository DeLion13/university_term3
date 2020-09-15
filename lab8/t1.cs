using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab3
{
    interface IProduct
    {
        string Cook();
    }
    class Meat : IProduct
    {
        public String Cook()
        {
            return "Tasty meat!!!";
        }
    }
    class Garnir : IProduct
    {
        public String Cook()
        {
            return "Just garnir...";
        }
    }

    class NoFood : IProduct
    {
        public String Cook()
        {
            return "Nothing :(";
        }
    }

    class Creator
    {
        public IProduct FactoryMethod()
        {
            
            if (Counter.DecreaseMeatCount() > 0)
            {
                return new Meat();
            }
            else if (Counter.DecreaseGarnirCount() > 0)
            {
                return new Garnir();
            }
            return new NoFood();
        }
    }

    public class Counter
    {
        public static Counter currentCount;

        public static int count_meat;
        public static int count_garnir;
        private Counter(int count)
        {
            count_meat = count;
            count_garnir = count;
        }
        public static int DecreaseMeatCount()
        {
            if (count_meat > 0)
            {
                return count_meat--;
            }
            else
            {
                return 0;
            }
        }

        public static int DecreaseGarnirCount()
        {
            if (count_garnir > 0)
            {
                return count_garnir--;
            }
            else {
                return 0;
            }
        }

        public static Counter getInstance(int count)
        {
            if (currentCount == null)
                currentCount = new Counter(count);
            return currentCount;
        }
    }

}
