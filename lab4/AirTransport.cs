namespace lab3
{
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
}