using System;
using System.Collections.Generic;

namespace lab3
{
    public class Hunter<T> where T : Transformer
    {
        public List<T> targets { get; set; }

        public string name { get; set; }
        public int strength { get; set; }
        public float velocity { get; set; }

        public List<T> Hunting()
        {
            List<T> new_l = new List<T>();
            for (int i = 0; i < targets.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (this.velocity > targets[i].velocity)
                {
                    new_l.Add(targets[i]);
                    Console.WriteLine(targets[i].name + " was killed by hunter " + this.name);
                }
                Console.ResetColor();
            }
            return new_l;
        }
    }
}