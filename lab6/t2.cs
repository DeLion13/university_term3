using System;

namespace lab1
{
    interface IPet
    {
        bool Voice();
    }
    class AbstractPet
    {
        IPet pet;
        public AbstractPet(IPet p)
        {
            this.pet = p;
        }
        public bool Voice()
        {
            return this.pet.Voice();
        }
    }
    class Cat : IPet
    {
        public string voice = "Mewww";
        public bool Voice()
        {
            Console.WriteLine("Cat: " + voice);
            return true;
        }
    }
    class Dog : IPet
    {
        public string voice = "Wawww";
        public bool Voice()
        {
            Console.WriteLine("Dog: " + voice);
            return true;
        }
    }

    class Cow : IPet
    {
        public string voice = "Muuuuu";
        public bool Voice()
        {
            Console.WriteLine("Cou: " + voice);
            return true;
        }
    }

    class Raven : IPet
    {
        public string voice = "Karrr";
        public bool Voice()
        {
            Console.WriteLine("Crow: " + voice);
            return true;
        }
    }
}