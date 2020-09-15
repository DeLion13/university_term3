using System;
using System.Collections.Generic;

namespace lab3
{
    public class Counter
    {
        public static Counter currentCount;

        public static int count;
        private Counter()
        {
            Console.WriteLine("Counter initialised by 0");
            count = 0;
        }
        public static int IncrementCount()
        {
            return ++count;
        }

        public static Counter getInstance()
        {
            if (currentCount == null)
                currentCount = new Counter();
            return currentCount;
        }
    }
    public class City
    {
        public string country;
        public string region;
        public string name_c;
        public City(string country, string region, string name_c)
        {
            this.country = country;
            this.region = region;
            this.name_c = name_c;
        }
        public City() : this("unknown", "unknown", "unknown")
        {
            Counter.IncrementCount();
        }

        public City(City obj) : this(obj.country, obj.region, obj.name_c)
        {
            Counter.IncrementCount();
        }
    }

     class CityList
    {
        List<string> cities = new List<string>();

        public CityList()
        {
            Console.WriteLine("New city list!");
        }

        public void addCity(string c)
        {
            cities.Add(c);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New city in list: " + c);
            Console.ResetColor();
        }

        public void destroyCity(string c)
        {
            int ind = cities.IndexOf(c);
            cities.RemoveAt(ind);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Transformers destroyed the city " + c);
            Console.ResetColor();
        }

        public void lookupCities()
        {
            Console.WriteLine("CITIES:");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < this.cities.Count; i++)
            {
                Console.WriteLine("Punkt " + i.ToString() + " : " + this.cities[i]);
            }
            Console.ResetColor();
        }
    }
}