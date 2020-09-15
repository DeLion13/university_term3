using System;

namespace lab1
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

    static class Hello
    {
        static string str = "===System loaded===";
        static Hello()
        {
            Console.WriteLine(str);
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

    public abstract class Transport
    {
        public City city;
        public int x;
        public int y;
        public int velocity;
        public string name;
        abstract public void go(int x, int y);
        public virtual void voice()
        {
            Console.WriteLine("Erondondon!");
        }
    }

    public class WaterTransport : Transport
    {
        public const string _platform = "Water";
        private string example = "This is platform: ";
        static double way(int x, int y)
        {
            return Math.Sqrt((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2));
        }
        public override void go(int x, int y)
        {
            double z = way(x - this.x, y - this.y);
            Console.WriteLine("Lenght of the way: " + z.ToString() + " km");
            Console.WriteLine("Velocity of \"" + this.name + "\" : " + this.velocity.ToString() + " kmph");
            Console.WriteLine("Time: " + (z / (double)this.velocity).ToString() + " h");
            this.x = x;
            this.y = y;
        }

        public WaterTransport()
        {
            this.x = this.y = this.velocity = 0;
            this.name = "null";
            this.city = new City();
        }

        public override void voice()
        {
            Console.WriteLine("Pshhshshsh!");
        }
        public string platform
        {
            get { return example + _platform; }
            set
            {
                if (value != null)
                {
                    example = value;
                }
                else
                {
                    Console.WriteLine("You didn`t input a stroke. I will set it to \"null\"");
                    example = "null";
                }
            }
        }
    }

    #region water

    public class bigShip : WaterTransport
    {
        static int count = 0;
        public int pass_seats;
        public int work_seats;
        readonly public int count_o_boats;
        public bigShip(City city, int x, int y, string name, int velocity, int pass_seats, int work_seats)
        {
            this.city = city;
            this.x = x;
            this.y = y;
            this.name = name;
            this.velocity = velocity;
            this.pass_seats = pass_seats;
            this.work_seats = work_seats;
            this.count_o_boats = (pass_seats + work_seats) / 10;
            Counter.IncrementCount();
            count++;
        }
        public bigShip()
        {
            this.velocity = 0;
            this.pass_seats = 0;
            this.work_seats = 0;
            this.count_o_boats = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    public class smallShip : WaterTransport
    {
        public int seats;
        static int count = 0;
        public smallShip(City city, int x, int y, string name, int velocity, int seats)
        {
            this.city = city;
            this.x = x;
            this.y = y;
            this.name = name;
            this.velocity = velocity;
            this.seats = seats;
            Counter.IncrementCount();
            count++;
        }
        public smallShip()
        {
            this.velocity = 0;
            this.seats = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    #endregion

    public class GroundTransport : Transport
    {
        const string _platform = "Ground";
        private string example = "This is platform: ";
        static int way(int x, int y)
        {
            return x + y;
        }
        public override void go(int x, int y)
        {
            int z = way(x - this.x, y - this.y);
            Console.WriteLine("Lenght of the way: " + z.ToString() + " km");
            Console.WriteLine("Velocity of \"" + this.name + "\" : " + this.velocity.ToString() + " kmph");
            Console.WriteLine("Time: " + ((double)z / (double)this.velocity).ToString() + " h");
            this.x = x;
            this.y = y;
        }
        public GroundTransport()
        {
            this.x = this.y = this.velocity = 0;
            this.name = "null";
            this.city = new City();
        }
        public override void voice()
        {
            Console.WriteLine("Beeep!");
        }

        public string platform
        {
            get { return example + _platform; }
            set
            {
                if (value != null)
                {
                    example = value;
                }
                else
                {
                    Console.WriteLine("You didn`t input a stroke. I will set it to \"null\"");
                    example = "null";
                }
            }
        }
    }

    #region ground

    public class car : GroundTransport
    {
        public int doors;
        static int count = 0;
        public car(City city, int x, int y, string name, int velocity, int doors)
        {
            this.city = city;
            this.x = x;
            this.y = y;
            this.name = name;
            this.velocity = velocity;
            this.doors = doors;
            Counter.IncrementCount();
            count++;
        }
        public car()
        {
            this.velocity = 0;
            this.doors = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    public class tram : GroundTransport
    {
        public int seats;
        public int places;
        static int count = 0;
        public tram(City city, int x, int y, string name, int velocity, int seats, int places)
        {
            this.city = city;
            this.x = x;
            this.y = y;
            this.name = name;
            this.velocity = velocity;
            this.seats = seats;
            this.places = places;
            Counter.IncrementCount();
            count++;
        }
        public tram()
        {
            this.velocity = 0;
            this.seats = 0;
            this.places = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    #endregion

    public class AirTransport : Transport
    {
        const string _platform = "Air";
        private string example = "This is platform: ";
        static double way(int x, int y)
        {
            return Math.Sqrt((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2));
        }
        public override void go(int x, int y)
        {
            double z = way(x - this.x, y - this.y);
            Console.WriteLine("Lenght of the way: " + z.ToString() + " km");
            Console.WriteLine("Velocity of \"" + this.name + "\" : " + this.velocity.ToString() + " kmph");
            Console.WriteLine("Time: " + (z / (double)this.velocity).ToString() + " h");
            this.x = x;
            this.y = y;
        }
        public AirTransport()
        {
            this.x = this.y = this.velocity = 0;
            this.name = "null";
            this.city = new City();
        }
        public override void voice()
        {
            Console.WriteLine("Uiiiiiiii!");
        }
        public string platform
        {
            get { return example + _platform; }
            set
            {
                if (value != null)
                {
                    example = value;
                }
                else
                {
                    Console.WriteLine("You didn`t input a stroke. I will set it to \"null\"");
                    example = "null";
                }
            }
        }
    }

    #region air

    public class airplane : AirTransport
    {
        public int engines;
        public int pass_seats;
        static int count = 0;
        public airplane(City city, int x, int y, string name, int velocity, int engines, int pass_seats)
        {
            this.city = city;
            this.x = x;
            this.y = y;
            this.name = name;
            this.velocity = velocity;
            this.engines = engines;
            this.pass_seats = pass_seats;
            Counter.IncrementCount();
            count++;
        }
        public airplane()
        {
            this.velocity = 0;
            this.engines = 0;
            this.pass_seats = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    public class helicopter : AirTransport
    {
        public int seats;
        static int count = 0;
        public helicopter(City city, int x, int y, string name, int velocity, int seats)
        {
            this.city = city;
            this.x = x;
            this.y = y;
            this.name = name;
            this.velocity = velocity;
            this.seats = seats;
            Counter.IncrementCount();
            count++;
        }
        public helicopter()
        {
            this.velocity = 0;
            this.seats = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    #endregion

    public class Program
    {
        static void Main(string[] args)
        {
            // Hello h = new Hello();
            Counter counter = Counter.getInstance();
            City c = new City();
            Console.WriteLine(c.country + " " + c.region + " " + c.name_c);
            City c1 = new City("Ukraine", "Kyiv Region", "Vishgorod");
            Console.WriteLine(c1.country + " " + c1.region + " " + c1.name_c + " " + Counter.count);
            City c2 = new City(c1);
            Console.WriteLine(c2.country + " " + c2.region + " " + c2.name_c + " " + Counter.count);
            bigShip d = new bigShip();
            // d.go(100, 20);
            Console.WriteLine(d.platform);
            d.platform = null;
            Console.WriteLine(d.platform);
        }
    }
}
