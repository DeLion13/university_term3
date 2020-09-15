using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;


namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============================================TASK-1=============================================");

            ClientCenter c = new ClientCenter();
            HelpCenter h = new HelpCenter();
            TechnicalCenter t = new TechnicalCenter();

            Client[] klass = new Client[3];
            klass[0] = new Client();
            klass[1] = new Client();
            klass[2] = new Client();

            Question[] tasks = new Question[3];
            tasks[0] = new Question();
            tasks[1] = new Question();
            tasks[2] = new Question();

            klass[0].CallDep(tasks[0], c);
            klass[1].CallDep(tasks[1], h);
            klass[2].CallDep(tasks[2], t);

            for (int i = 0; i < 3; i++) {
                klass[i].AskByHimself(tasks[i]);
            }

            Console.WriteLine("=============================================TASK-2=============================================");

            Starosta starosta = new Starosta();

            Participant student1 = new Student("Maeve");
            Participant student2 = new Student("Eric");
            Participant student3 = new Student("Adam");
            Participant student4 = new Student("Otis");
            Participant Headteacher = new Headteacher("Groff");

            starosta.RegisterToList(student1);
            starosta.RegisterToList(student2);
            starosta.RegisterToList(student3);
            starosta.RegisterToList(student4);

            starosta.RegisterToList(Headteacher);

            // List<StudentStruct> list = new List<StudentStruct>();

            // for (int i = 0; i < 5; i++) {
            //     StudentStruct st = new StudentStruct();
            //     st.name = i.ToString();
            //     st.age = i;
            //     list.Add(st);
            // }

            StudentStruct student_1 = new StudentStruct();
            student_1.name = student1.Name;
            student_1.age = 12;

            StudentStruct student_2 = new StudentStruct();
            student_2.name = student2.Name;
            student_2.age = 12;

            StudentStruct student_3 = new StudentStruct();
            student_3.name = student3.Name;
            student_3.age = 12;

            StudentStruct student_4 = new StudentStruct();
            student_4.name = student4.Name;
            student_4.age = 12;

            student1.SendInfo("Groff", student_1);
            student2.SendInfo("Groff", student_2);
            student3.SendInfo("Groff", student_3);
            student4.SendInfo("Groff", student_4);

            Console.ReadKey();
        }
    }
}
