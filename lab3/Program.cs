using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace lab3
{
    delegate double Operation(int x, int y);
    public delegate void Action<T>(T obj);

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

    interface IWaterTransport
    {
        double way(int x, int y);
        void voice();
    }
    interface IWaterTransportVoice
    {
        void voice();
    }

    public class WaterTransport : Transport, IWaterTransport, IWaterTransportVoice
    {
        // static double sqr_sum(int x, int y) {
        //     return Math.Sqrt((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2));
        // }
        // event Operation sqr_sum;
        Operation sqr_sum = delegate (int x, int y)
        {
            return Math.Sqrt((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2));
        };

        public const string _platform = "Water";
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
        void IWaterTransportVoice.voice()
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

    public class BigShip : WaterTransport
    {
        static int count = 0;
        public int pass_seats;
        public int work_seats;
        readonly public int count_o_boats;
        public BigShip(City city, int x, int y, string name, int velocity, int pass_seats, int work_seats)
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
        public BigShip()
        {
            this.velocity = 0;
            this.pass_seats = 0;
            this.work_seats = 0;
            this.count_o_boats = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    public class SmallShip : WaterTransport
    {
        static int count = 0;
        public int seats;
        public SmallShip(City city, int x, int y, string name, int velocity, int seats)
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
        public SmallShip()
        {
            this.velocity = 0;
            this.seats = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    #endregion
    interface IGroundTransport
    {
        int way(int x, int y);
    }
    interface IGroundTransportVoice
    {
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

        static void toStr(double x, double y)
        {
            Console.Write((x / y).ToString());
        }
        //////////////ACTION!!!!!!!!!!?????????????????????/
        static void Act(int x1, int x2, Action<int, int> op)
        {
            op(x1, x2);
        }
        public override void go(int x, int y)
        {
            Action<double, double> op;
            op = toStr;
            int z = way(x - this.x, y - this.y);
            Console.WriteLine("Lenght of the way: " + z.ToString() + " km");
            Console.WriteLine("Velocity of \"" + this.name + "\" : " + this.velocity.ToString() + " kmph");
            Console.Write("Time: ");
            op(z, this.velocity);
            Console.Write(" h");
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

    public class Car : GroundTransport
    {
        static int count = 0;
        public int doors;
        public Car(City city, int x, int y, string name, int velocity, int doors)
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
        public Car()
        {
            this.velocity = 0;
            this.doors = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    public class Tram : GroundTransport
    {
        static int count = 0;
        public int seats;
        public int places;
        public Tram(City city, int x, int y, string name, int velocity, int seats, int places)
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
        public Tram()
        {
            this.velocity = 0;
            this.seats = 0;
            this.places = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    #endregion
    interface IAirTransport
    {
        double way(int x, int y);
    }
    interface IAirTransportVoice
    {
        void voice();
    }
    public class AirTransport : Transport, IAirTransport, IAirTransportVoice
    {
        // public double sqr_sum(int x, int y)
        // {
        //     return Math.Sqrt((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2));
        // }
        Operation sqr_sum = (x, y) => Math.Sqrt((int)Math.Pow(x, 2) + (int)Math.Pow(y, 2));
        const string _platform = "Air";
        private string example = "This is platform: ";
        public double way(int x, int y)
        {
            return sqr_sum(x, y);
        }
        /////////////////////FUNC!!FUNC!!!!!FUNC!!!!!!!!!!!!!!!!
        static double Over(double x, double y, Func<double, double, double> op)
        {
            return op(x, y);
        }

        static double decr(double x, double y)
        {
            return x / y;
        }

        public override void go(int x, int y)
        {
            Func<double, double, double> op;
            op = decr;
            double z = way(x - this.x, y - this.y);
            Console.WriteLine("Lenght of the way: " + z.ToString() + " km");
            Console.WriteLine("Velocity of \"" + this.name + "\" : " + this.velocity.ToString() + " kmph");
            Console.WriteLine("Time: " + decr(z, this.velocity).ToString() + " h");
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

    public class Airplane : AirTransport
    {
        static int count = 0;
        public int engines;
        public int pass_seats;
        public Airplane(City city, int x, int y, string name, int velocity, int engines, int pass_seats)
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
        public Airplane()
        {
            this.velocity = 0;
            this.engines = 0;
            this.pass_seats = 0;
            Counter.IncrementCount();
            count++;
        }
    }

    public class Helicopter : AirTransport
    {
        static int count = 0;
        public int seats;
        public Helicopter(City city, int x, int y, string name, int velocity, int seats)
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
        public Helicopter()
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

    public class Transformer : IComparable<Transformer>
    {
        public City city;
        public int age;
        public int x;
        public int y;
        public string name;
        public int velocity;
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
        public int CompareTo(Transformer other)
        {
            int compare = this.velocity.CompareTo(other.velocity);
            if (compare == 0)
            {
                compare = this.name.CompareTo(other.name);
                compare = -compare;
            }
            return compare;
        }
        public Transformer(string name, int velocity)
        {
            this.velocity = velocity;
            this.name = name;
        }

        public Transformer getCopy()
        {
            return this;
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public City City
        {
            get { return city; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Vel
        {
            get { return velocity; }
            set { velocity = value; }
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

    class TransformerList : IEnumerable
    {
        private Transformer[] _transformers;
        public TransformerList(Transformer[] pArray)
        {
            _transformers = new Transformer[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _transformers[i] = pArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public TransformersEnum GetEnumerator()
        {
            return new TransformersEnum(_transformers);
        }
    }

    public class TransformersEnum : IEnumerator
    {
        public Transformer[] _transformers;
        int position = -1;
        public TransformersEnum(Transformer[] list)
        {
            _transformers = list;
        }
        public bool MoveNext()
        {
            position++;
            Console.WriteLine("Ster #" + position);
            return (position < _transformers.Length);
        }
        public void Reset()
        {
            position = -1;
        }


        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Transformer Current
        {
            get
            {
                try
                {
                    return _transformers[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public static class OperateTransformerExtension
    {
        public static int NumOfTrans(this List<Transformer> transformers)
        {
            return transformers.Count;
        }
    }

    class OperateTransformer : IComparable<int>
    {
        
        List<Transformer> transformers = new List<Transformer>();
        public OperateTransformer()
        {
            transformers.Add(new Transformer(new City(), 0, 0, "Bee", 200, 0));
            transformers.Add(new Transformer(new City(), 100, 1000, "Optimus Prime", 400, 100));
        }

        public int CompareTo(int count)
        {
            if (this.transformers.Count > count)
            {
                Console.WriteLine("Transformers can start the WAR!!!");
                return 1;
            }
            else if (this.transformers.Count < count)
            {
                Console.WriteLine("Transformers cannot start the WAR!!!");
                return -1;
            }
            else
            {
                Console.WriteLine("Strength are equals!!!");
                return 0;
            }
        }
        public Transformer this[string name] { 
            get { 
                return transformers.FindAll((tr) => (tr.name == name))[0];
            } 
 
            set { 
                transformers.ForEach((tr) => { 
                    if (tr.name == name) { 
                        tr = value;
                    } 
                }); 
            }
        }

        public void killTransformer(string name)
        {
            for (int i = 0; i < transformers.Count; i++)
            {
                if (transformers[i].name == name)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Our army killed " + transformers[i].name);
                    Console.ResetColor();
                    transformers.RemoveAt(i);
                }
            }
        }

        public void newProtokolTransformer(Transformer tr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Our army found " + tr.name);
            Console.ResetColor();
            transformers.Add(tr);
        }

        public void showProtokol()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < this.transformers.Count; i++)
            {
                Console.WriteLine("Punkt " + i.ToString() + " : " + this.transformers[i].name);
            }
            Console.ResetColor();
        }

        public List<Transformer> getTransformers()
        {
            return transformers;
        }
    }

    public class Hunter<T> where T : Transformer
    {
        public List<T> targets { get; set; }
        
        public string name { get; set; }
        public int strength { get; set; }
        public float velocity { get; set; }

        public List<T> Hunting() {
            List<T> new_l = new List<T>();
            for (int i = 0; i < targets.Count; i++) {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (this.velocity > targets[i].velocity) {
                    new_l.Add(targets[i]);
                    Console.WriteLine(targets[i].name + " was killed by hunter " + this.name);
                }
                Console.ResetColor();
            }
            return new_l;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string WritePath = @"./info/text.json";
            string WritePathXml = @"./info/text.xml";

            try
            {
                City c = new City();
                City c1 = new City("Ukraine", "Kyiv Region", "Vishgorod");
                City c2 = new City(c1);
                CityList c_list = new CityList();
                c_list.addCity(c.name_c);
                c_list.addCity(c1.name_c);
                c_list.addCity(c2.name_c);
                c_list.destroyCity(c1.name_c);


                c_list.lookupCities();
                Console.WriteLine("");
                Console.WriteLine("LIST WITH ENUMERATE INTERFACE:");
                Console.WriteLine("==============");

                Transformer[] transArray = new Transformer[4]
                {
                    new Transformer() { name = "Transformer John", velocity = 165},
                    new Transformer() { name = "Transformer  Jim", velocity = 155},
                    new Transformer() { name = "Transformer  Sue", velocity = 145},
                    new Transformer() { name = "Transformer  Sue", velocity = 121}
                };

                TransformerList transList = new TransformerList(transArray);
                foreach (Transformer p in transList)
                {
                    Console.WriteLine(p.name + " " + p.velocity);
                }

                Console.WriteLine("LIST WITH ICOMPATIBLE INTERFACE:");

                var transf = new List<Transformer>
                {
                    new Transformer() { name = "Transformer John", velocity = 165},
                    new Transformer() { name = "Transformer  Jim", velocity = 155},
                    new Transformer() { name = "Transformer  Sue", velocity = 145},
                    new Transformer() { name = "Transformer  Sue", velocity = 121}
                };
                transf.Sort();
                foreach (Transformer p in transf)
                {
                    Console.WriteLine("name: " + p.name + ", " + "velocity: " + p.velocity);
                }
                Console.WriteLine("===================");
                Console.WriteLine("");

                Transformer tr = new Transformer(new City(), 0, 0, "Slide", 100, 41);
                OperateTransformer city = new OperateTransformer();
                city.killTransformer("Bee");
                city.newProtokolTransformer(tr);
                city.CompareTo(4);

                List<Transformer> copy = city.getTransformers();

                Console.WriteLine("Army of transformers just of " + copy.NumOfTrans() + " members.");
                ///////////
                Console.WriteLine("\nJSON SERIALIZE\n");
                JsonSerializerOptions op = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                using (StreamWriter sw = new StreamWriter(WritePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(JsonSerializer.Serialize<List<Transformer>>(transf, op));
                }
                using (StreamReader sr = new StreamReader(WritePath, System.Text.Encoding.Default))
                {
                    string txt = null;
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        txt = txt + line;
                    }
                    List<Transformer> t = JsonSerializer.Deserialize<List<Transformer>>(txt, op);
                    Console.WriteLine("    NAME       " + " " + "AGE" + " " + "VELOCITY");
                    foreach (Transformer i in t)
                    {
                        Console.WriteLine(i.Name + " " + i.Age + "    " + i.Vel);
                    }
                }
                ////////////////////////
                Console.WriteLine("\nXML SERIALIZE\n");
                XmlSerializer formatter = new XmlSerializer(typeof(List<Transformer>));
                using (FileStream fs = new FileStream(WritePathXml, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, transf);
                }

                using (FileStream fs = new FileStream(WritePathXml, FileMode.OpenOrCreate))
                {
                    List<Transformer> t = (List<Transformer>)formatter.Deserialize(fs);
                    Console.WriteLine("    NAME       " + " " + "AGE" + " " + "VELOCITY");
                    foreach (Transformer i in t)
                    {
                        Console.WriteLine(i.Name + " " + i.Age + "    " + i.Vel);
                    }
                }
                Console.Write("\n");
                /////////////////////////////////////////////////////////////////////
                Hunter<Transformer> hunt = new Hunter<Transformer> { name = "Turuk", targets = transf, velocity = 1000, strength = 2 };
                if (hunt.velocity > tr.velocity)
                {
                    Console.WriteLine(tr.name + " was killed by hunter " + hunt.name);
                }

            }
            catch (ExceptionFind ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}{ex.Value}");
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("Fin");
            }
        }
    }
}
