using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Threading;

namespace lab3
{
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
}