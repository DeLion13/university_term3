using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab2
{
    class ColorFactory
    {
        private Dictionary<char, Color> _color = new Dictionary<char,Color>();
        public Color GetColor(char key)
        {
            // Uses "lazy initialization"
            Color color = null;
            if (_color.ContainsKey(key))
            {
                color = _color[key];
            }
            else
            {
                switch (key)
                {
                    case 'R': color = new ColorRed('*'); break;
                    case 'B': color = new ColorBlue('-'); break;
                    case 'G': color = new ColorGreen('+'); break;
                    case 'C': color = new ColorCyan('='); break;
                    case 'Y': color = new ColorYellow('/'); break;
                    case 'D': color = new ColorBlack('?'); break;
                }

                _color.Add(key, color);

            }
            return color;
        }
    }
    abstract class Color
    {
        protected char symbol;
        protected ConsoleColor color;
        public abstract void Display();
    }

    class ColorRed : Color
    {
        public ColorRed(char symbol)
        {
            this.color = ConsoleColor.Red;
            this.symbol = symbol;
        }
        public override void Display()
        {
            Console.BackgroundColor = this.color;
            Console.Write(this.symbol);
            Console.Write(this.symbol);
            Console.ResetColor();
        }
    }
    class ColorBlue : Color
    {
        public ColorBlue(char symbol)
        {
            this.color = ConsoleColor.Blue;
            this.symbol = symbol;
        }
        public override void Display()
        {
            Console.BackgroundColor = this.color;
            Console.Write(this.symbol);
            Console.Write(this.symbol);
            Console.ResetColor();
        }
    }
    class ColorGreen : Color
    {
        public ColorGreen(char symbol)
        {
            this.color = ConsoleColor.Green;
            this.symbol = symbol;
        }
        public override void Display()
        {
            Console.BackgroundColor = this.color;
            Console.Write(this.symbol);
            Console.Write(this.symbol);
            Console.ResetColor();
        }
    }

    class ColorCyan : Color
    {
        public ColorCyan(char symbol)
        {
            this.color = ConsoleColor.Cyan;
            this.symbol = symbol;
        }
        public override void Display()
        {
            Console.BackgroundColor = this.color;
            Console.Write(this.symbol);
            Console.Write(this.symbol);
            Console.ResetColor();
        }
    }

    class ColorYellow : Color
    {
        public ColorYellow(char symbol)
        {
            this.color = ConsoleColor.Yellow;
            this.symbol = symbol;
        }
        public override void Display()
        {
            Console.BackgroundColor = this.color;
            Console.Write(this.symbol);
            Console.Write(this.symbol);
            Console.ResetColor();
        }
    }

    class ColorBlack : Color
    {
        // Constructor
        public ColorBlack(char symbol)
        {
            this.color = ConsoleColor.Black;
            this.symbol = symbol;
        }
        public override void Display()
        {
            Console.BackgroundColor = this.color;
            Console.Write(this.symbol);
            Console.Write(this.symbol);
            Console.ResetColor();
        }
    }
}