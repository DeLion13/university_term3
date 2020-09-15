using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Threading;

namespace lab3
{
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
}