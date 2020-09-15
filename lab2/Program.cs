using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace lab2
{
    delegate double Operation(int x, int y);

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

    public abstract class Transport
    {
        public City city;
        public int x;
        public int y;
        public int velocity;
        public string name;
        abstract public void go(int x, int y);
    }

    interface IWaterTransport {
        double way(int x, int y);
        void voice();
    }
    interface IWaterTransportVoice {
        void voice();
    }

    public class WaterTransport : Transport, IWaterTransport, IWaterTransportVoice
    {
        // static double sqr_sum(int x, int y) {
        //     return Math.Sqrt((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2));
        // }
        event Operation sqr_sum;
        public const string _platform = "Water";
        private string example = "This is platform: ";
        AirTransport del = new AirTransport();
        public double way(int x, int y)
        {
            sqr_sum = del.sqr_sum;
            return sqr_sum(x, y);
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

        void IWaterTransport.voice()
        {
            Console.WriteLine("Water breethe!");
        }
        void IWaterTransportVoice.voice() {
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
        static int count = 0;
        public int seats;
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
    interface IGroundTransport {
        int way(int x, int y);
    }
    interface IGroundTransportVoice {
        void voice();
    }
    
    public class GroundTransport : Transport, IGroundTransport, IGroundTransportVoice
    {
        const string _platform = "Ground";
        private string example = "This is platform: ";
        public int way(int x, int y)
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
        public void voice()
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
        static int count = 0;
        public int doors;
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
        static int count = 0;
        public int seats;
        public int places;
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
    interface IAirTransport {
        double way(int x, int y);
    }
    interface IAirTransportVoice {
        void voice();
    }
    public class AirTransport : Transport, IAirTransport, IAirTransportVoice
    {
        public double sqr_sum(int x, int y) {
            return Math.Sqrt((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2));
        }
        // Operation square = sqr_sum;
        const string _platform = "Air";
        private string example = "This is platform: ";
        public double way(int x, int y)
        {
            return sqr_sum(x, y);
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
        public void voice()
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
        static int count = 0;
        public int engines;
        public int pass_seats;
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
        static int count = 0;
        public int seats;
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

    class ExceptionFind : ArgumentException
    {
        public int Value { get; }
        public ExceptionFind(string message, int val)
            : base(message)
        {
            Value = val;
        }

    }

    public class Transformer : GroundTransport
    {
        public int age;
        public Transformer(City city, int x, int y, string name, int velocity, int age)
        {
            this.city = city;
            this.x = x;
            this.y = y;
            this.name = name;
            this.velocity = velocity;
            this.age = age;
        }
        public Transformer()
        {
            this.velocity = 0;
            this.age = 0;
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 10)
                {
                    throw new ExceptionFind("Less then 10 years: Small transformer to kill him! His age: ", value);
                }
                else
                {
                    age = value;
                }
            }
        }
    }

    class FindTransformer
    {
        Transformer[] transformers;
        public FindTransformer() {
            transformers = new Transformer[2];
            transformers[0] = new Transformer(new City(), 0, 0, "Bee", 200, 0);
            transformers[1] = new Transformer(new City(), 100, 1000, "Optimus Prime", 400, 100);
        }

        public Transformer[] Transformers
        {
            get { return transformers; }
            set { transformers = value; }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try {
                Counter counter = Counter.getInstance();
                City c = new City();
                Console.WriteLine(c.country + " " + c.region + " " + c.name_c);
                City c1 = new City("Ukraine", "Kyiv Region", "Vishgorod");
                Console.WriteLine(c1.country + " " + c1.region + " " + c1.name_c + " " + Counter.count);
                City c2 = new City(c1);
                Console.WriteLine(c2.country + " " + c2.region + " " + c2.name_c + " " + Counter.count);
                bigShip d = new bigShip();
                IWaterTransport new_trans = new bigShip();
                new_trans.voice();
                d.go(100, 20);
                Console.WriteLine(d.platform);
                d.platform = null;
                Console.WriteLine(d.platform);
                Console.WriteLine("");

                Transformer[] trans;
                FindTransformer f = new FindTransformer();
                trans = f.Transformers;
                trans[0].Age = 9;
            } catch (ExceptionFind ex) {
                Console.WriteLine($"Error occured: {ex.Message}{ex.Value}");
            } finally {
                Console.WriteLine("");
                Console.WriteLine("Fin");
            }
        }
    }
}
