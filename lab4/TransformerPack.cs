using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab3
{
    public class Transformer : IComparable<Transformer>, IDisposable
    {
        private bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private bool hasFinalized = false;
        public static Transformer currentInstance = null;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }

        ~Transformer()
        {
            if (hasFinalized == false)
            {
                // Console.WriteLine("Fin: 1");
                Transformer.currentInstance = this;
                hasFinalized = true;
                GC.ReRegisterForFinalize(this);
            }
            else
            {
                // Console.WriteLine("Fin: 2");
            }
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

    class OperateTransformer : IComparable<int>, IDisposable
    {

        List<Transformer> transformers = new List<Transformer>();
        private bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public OperateTransformer()
        {
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
        public Transformer this[string name]
        {
            get
            {
                return transformers.FindAll((tr) => (tr.name == name))[0];
            }

            set
            {
                transformers.ForEach((tr) =>
                {
                    if (tr.name == name)
                    {
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
        public void Dispose()
        {
            // Console.WriteLine("Supp");
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            // Console.WriteLine("Disp");
            disposed = true;
        }
        public void gen(int i)
        {
            transformers.Add(new Transformer(new City(), i, i, "Slide", i, i));
        }

        ~OperateTransformer()
        {
            Console.WriteLine("Destr");
            Dispose(false);
        }

    }
}