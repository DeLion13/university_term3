using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab1
{
    abstract class HospitalComponent
    {
        protected string name;
        protected int people;
        protected string type;
        // Constructor
        public HospitalComponent(string name)
        {
            this.name = name;
        }
        public abstract void Add(HospitalComponent c);
        public abstract void Remove(HospitalComponent c);
        public abstract int GetPeopleInfo();
        public abstract void Display(int depth);
        public abstract List<HospitalComponent> ReturnCopy();
    }

    class Composite : HospitalComponent
    {
        private List<HospitalComponent> _children = new List<HospitalComponent>();
        // Constructor
        public Composite(string name, string type) : base(name)
        {
            this.type = type;
            if (type == "Department")
            {
                Random rnd = new Random();
                this.people = rnd.Next(150);
            }
            else
            {
                this.people = 0;
            }
        }
        public override void Add(HospitalComponent component)
        {
            _children.Add(component);
        }
        public override void Remove(HospitalComponent component)
        {
            _children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name + " " + this.people.ToString());

            foreach (HospitalComponent component in _children)
                component.Display(depth + 2);
        }
        public override int GetPeopleInfo()
        {
            if (this.type != "Department")
            {
                this.people = 0;
            }

            foreach (HospitalComponent component in _children)
                this.people += component.GetPeopleInfo();

            return this.people;
        }
        public override List<HospitalComponent> ReturnCopy()
        {
            List<HospitalComponent> comps = _children;
            return comps;
        }
    }

    class Doctor : HospitalComponent
    {
        public string docName;
        public Doctor(string name) : base(name)
        {
            this.docName = name;
        }
        public override void Add(HospitalComponent c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Remove(HospitalComponent c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
        public override int GetPeopleInfo()
        {
            return this.people;
        }
        public override List<HospitalComponent> ReturnCopy()
        {
            return null;
        }
    }

    class Client
    {
        public string name;
        public List<Doctor> hosp = new List<Doctor>();
        Random rnd = new Random();
        public Client(string name, HospitalComponent hosp)
        {
            this.name = name;
            List<HospitalComponent> deps = hosp.ReturnCopy();

            foreach (Composite dep in deps)
            {
                List<HospitalComponent> docs = dep.ReturnCopy();
                foreach (Doctor doc in docs)
                {
                    this.hosp.Add(doc);
                }
            }
        }

        public void checkOneDoctor()
        {
            Console.WriteLine("One doctor:");
            Console.WriteLine("   He/She met one doctor: " + this.hosp[rnd.Next(this.hosp.Count - 1)].docName);
        }

        public void checkSomeDoctors()
        {
            Console.WriteLine("Some doctors:");
            for (int i = 0; i < this.hosp.Count; i++)
            {
                if (rnd.Next(2) == 1)
                {
                    Console.WriteLine("  He/She met doctor: " + this.hosp[i].docName);
                }
            }
        }

        public void checkAllDoctors()
        {
            Console.WriteLine("All doctors:");
            for (int i = 0; i < this.hosp.Count; i++)
            {
                Console.WriteLine("  He/She met doctor: " + this.hosp[i].docName);
            }
        }
    }
}