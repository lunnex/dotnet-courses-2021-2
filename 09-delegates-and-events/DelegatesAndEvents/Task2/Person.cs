using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
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
}
