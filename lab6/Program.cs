using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============Task1============");

            Composite hospital = new Composite("KPI Clinic", "Hospital");

            Composite comp1 = new Composite("Surgery", "Department");
            Composite comp2 = new Composite("Traumatology", "Department");
            Composite comp3 = new Composite("Viral", "Department");

            Doctor doctor1 = new Doctor("Jeen Milburn");
            Doctor doctor2 = new Doctor("Otis Milburn");
            Doctor doctor3 = new Doctor("Maeve Wyley");
            Doctor doctor4 = new Doctor("Eric Efeong");
            Doctor doctor5 = new Doctor("Adam Groff");
            Doctor doctor6 = new Doctor("Jakson Marchette");

            comp1.Add(doctor1);
            comp1.Add(doctor2);

            comp2.Add(doctor3);
            comp2.Add(doctor4);

            comp3.Add(doctor5);
            comp3.Add(doctor6);

            hospital.Add(comp1);
            hospital.Add(comp2);
            hospital.Add(comp3);
            
            hospital.GetPeopleInfo();
            hospital.Display(2);

            Client new1 = new Client("Lilly", hospital);

            new1.checkOneDoctor();
            new1.checkSomeDoctors();
            new1.checkAllDoctors();

            Console.WriteLine("============Task2============");
            List<AbstractPet> passengers = new List<AbstractPet>{
                new AbstractPet(new Cat()),
                new AbstractPet(new Dog()),
                new AbstractPet(new Cow()),
                new AbstractPet(new Raven())
            };
            foreach (AbstractPet ap in passengers)
            {
                ap.Voice();
            }
            Console.ReadKey();
        }
    }
}
