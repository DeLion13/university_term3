using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab4
{
    interface IPrimitives
    {
        string Operation1();
        string Operation2();
        string Operation3();
        string Operation4();
    }

    class Algorithm
    {
        public void TemplateMethod(IPrimitives a)
        {
            string s = a.Operation1() + a.Operation2() + a.Operation3() + a.Operation4();
            Console.WriteLine(s);
        }
    }
    class Wash : IPrimitives
    {
        public string Operation1() {
            return "Use expensive shampoo! ";
        }
        public string Operation2() {
            return "Use conditioner shampoo! ";
        }
        public string Operation3() {
            return "Warm water! ";
        }
        public string Operation4() {
            return "Cold water!";
        }
    }
    class Comb : IPrimitives
    {
        public string Operation1() {
            return "Professional instruments! ";
        }
        public string Operation2() {
            return "Cleaning comb instruments! ";
        }
        public string Operation3() {
            return "Professional combing! ";
        }
        public string Operation4() {
            return "Ready to cutting!";
        }
    }

    class Cut : IPrimitives
    {
        public string Operation1() {
            return "Scissors! ";
        }
        public string Operation2() {
            return "Cutting machine! ";
        }
        public string Operation3() {
            return "Staight VISOK! ";
        }
        public string Operation4() {
            return "Correction!";
        }
    }

    class Drying : IPrimitives
    {
        public string Operation1() {
            return "Hair dryer! ";
        }
        public string Operation2() {
            return "Combing! ";
        }
        public string Operation3() {
            return "Styling! ";
        }
        public string Operation4() {
            return "Pay!";
        }
    }
}