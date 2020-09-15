using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Threading;

namespace lab3
{
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
}