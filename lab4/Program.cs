using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab3
{
    delegate double Operation(int x, int y);
    public delegate void Action<T>(T obj);

    public class Program
    {
        static WeakReference _weak;
        static WeakReference Alloc()
        {
            return new WeakReference(new object());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("========TEST1========");

            OperateTransformer city = new OperateTransformer();

            for (int i = 0; i < 1000; i++)
            {
                city.gen(i);
            }
            Console.WriteLine("\nAfter loop:\n");

            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

            city = null;

            for (int i = 0; i < 1000; i++)
            {
                city = new OperateTransformer();
                // city.Dispose(); // GC for memory
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

            Console.WriteLine("\nHighest gen: {0}", GC.MaxGeneration);

            Transformer tr = null;
            for (int i = 0; i < 30000; i++)
            {
                tr = new Transformer();
            }

            Console.WriteLine("GC: 0");
            Console.WriteLine("Generation: {0}", GC.GetGeneration(tr));
            Console.WriteLine("Total Memory: {0}\n", GC.GetTotalMemory(false));
            GC.Collect(0);

            Console.WriteLine("GC: 1");
            Console.WriteLine("Generation: {0}", GC.GetGeneration(tr));
            Console.WriteLine("Total Memory: {0}\n", GC.GetTotalMemory(false));
            GC.Collect(1);

            Console.WriteLine("GC: 2");
            Console.WriteLine("Generation: {0}", GC.GetGeneration(tr));
            Console.WriteLine("Total Memory: {0}\n", GC.GetTotalMemory(false));
            GC.Collect(2);

            GC.WaitForPendingFinalizers();

            Console.WriteLine("Total Memory in GC: {0}\n\n", GC.GetTotalMemory(false));


            _weak = Alloc();

            // See if weak reference is alive.
            if (_weak.IsAlive)
            {
                Console.WriteLine("Weak reference is alive");
            }

            Console.WriteLine("Generation for weak: {0}", GC.GetGeneration(_weak));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            GC.Collect(0);
            GC.WaitForPendingFinalizers();

            if (_weak.IsAlive)
            {
                Console.WriteLine("Weak referance is alive");
            }
            else
            {
                Console.WriteLine("Weak referance was deleted");
            }

            Console.WriteLine("Total Memory after weak referance deleting: {0}", GC.GetTotalMemory(false));
        }
    }
}
