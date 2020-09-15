using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab5
{
    class Client
    {
        public void CallDep(Question q, Department dep)
        {
            q._Department = dep;
        }
        public void AskByHimself(Question q)
        {
            q.Ask();
        }
    }
    class Question
    {
        protected Department dep;
        public Department _Department
        {
            set
            {
                dep = value;
            }
        }
        public int Ask()
        {
            if (dep != null)
                return dep.Answer();
            else
                return 2;
        }
    }
    //receiver
    abstract class Department
    {
        public abstract int Answer();
    }
    class HelpCenter : Department
    {
        public override int Answer()
        {
            Console.WriteLine("Hi! You called Help Center");
            return 3;
        }
    }
    class ClientCenter : Department
    {
        public override int Answer()
        {
            Console.WriteLine("Hi! You called Client Center");
            return 4;
        }
    }
    class TechnicalCenter : Department
    {
        public override int Answer()
        {
            Console.WriteLine("Hi! You called Technical Center");
            return 5;
        }
    }
}