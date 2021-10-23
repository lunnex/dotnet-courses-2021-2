using System;

namespace Task2
{
    class OfficeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Time { get; }

        public OfficeEventArgs(string _name)
        {
            Name = _name;
            Time = DateTime.Now.Hour;
        }

    }

    class Office
    {
        public event EventHandler<OfficeEventArgs> PersonCame;
        public event EventHandler<OfficeEventArgs> PersonLeft;

        public void Come (Person person)
        {
            PersonCame?.Invoke(this, new OfficeEventArgs(person.Name));
        }

        public void Left(Person person)
        {
            PersonLeft?.Invoke(this, new OfficeEventArgs(person.Name));
        }

    }

    class Person
    {
        public string Name { get; set; }

        public Person(string Name)
        {
            this.Name = Name;
        }

        public void SayHello(object sender, OfficeEventArgs PersonCame)
        {
            if (PersonCame.Time > 6 && PersonCame.Time <= 12)
            {
                Console.WriteLine($"[На работу пришел {PersonCame.Name}]");
                Console.WriteLine($"Доброе утро, {PersonCame.Name}, - сказал {Name}");
            }
            else if (PersonCame.Time > 12 && PersonCame.Time <= 17)
            {
                Console.WriteLine($"[На работу пришел {PersonCame.Name}]");
                Console.WriteLine($"Добрый день, {PersonCame.Name}, - сказал {Name}");
            }
            else if (PersonCame.Time > 17 && PersonCame.Time <= 23)
            {
                Console.WriteLine($"[На работу пришел {PersonCame.Name}]");
                Console.WriteLine($"Добрый вечер, {PersonCame.Name}, - сказал {Name}");
            }
            else
            {
                Console.WriteLine("Я сплю");
            }
        }

        public void SayBye(object sender, OfficeEventArgs PersonCame)
        {
            Console.WriteLine($"[{PersonCame.Name} ушел домой]");
            Console.WriteLine($"До свидания, {PersonCame.Name}, - сказал {Name}");
        }
    }

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
