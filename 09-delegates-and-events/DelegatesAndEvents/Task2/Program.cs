using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Pavel = new Person("Павел");
            Person Vladimir = new Person("Владимир");
            Person Sergey = new Person("Сергей");

            Office office = new Office();
            office.PersonCame += Pavel.SayHello;
            office.Come(Vladimir);
            office.Come(Sergey);
            office.PersonLeft += Vladimir.SayBye; 
            office.PersonLeft += Sergey.SayBye;
            office.Left(Pavel);
        }
    }
}
