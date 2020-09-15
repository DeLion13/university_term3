using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab5
{
    // The 'Mediator' abstract class
    class StudentStruct
    {
        public string name;
        public int age;
    }

    abstract class AbstractStarosta
    {
        public abstract void RegisterToList(Participant participant);
        public abstract void SendInfo(string from, string to, StudentStruct l);
    }
    // The 'ConcreteMediator' class
    class Starosta : AbstractStarosta
    {
        private Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();
        public override void RegisterToList(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }
            participant.Starosta = this;
        }
        public override void SendInfo(string from, string to, StudentStruct l)
        {
            Participant participant = _participants[to];
            if (participant != null)
            {
                participant.Receive(from, l);
            }
        }
    }
    // The 'AbstractColleague' class
    class Participant
    {
        private Starosta _room;
        private string _name;
        // Constructor
        public Participant(string name)
        {
            this._name = name;
        }
        // Gets participant name
        public string Name
        {
            get { return _name; }
        }
        // Gets chatroom
        public Starosta Starosta
        {
            set { _room = value; }
            get { return _room; }
        }
        // Sends message to given participant
        public void SendInfo(string to, StudentStruct l)
        {
            _room.SendInfo(_name, to, l);
        }
        // Receives message from given participant
        public virtual void Receive(string from, StudentStruct l)
        {
            Console.WriteLine("Student info throught starosta from {0} to {1}:", from, Name);
            Console.WriteLine("    " + l.name + " " + l.age);
        }
    }
    // A 'ConcreteColleague' class
    class Student : Participant
    {
        // Constructor
        public Student(string name)
        : base(name)
        {
        }
        public override void Receive(string from, StudentStruct l)
        {
            Console.Write("To a Student: ");
            base.Receive(from, l);
        }
    }
    // A 'ConcreteColleague' class
    class Headteacher : Participant
    {
        // Constructor
        public Headteacher(string name)
        : base(name)
        {
        }
        public override void Receive(string from, StudentStruct l)
        {
            Console.Write("To a Headteacher: ");
            base.Receive(from, l);
        }
    }
}
