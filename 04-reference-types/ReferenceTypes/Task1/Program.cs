﻿using System;

namespace Task1
{
    class User
    {
        private int _age = 0;
        private string _firstName = "";
        private string _secondName = "";
        private string _patronymic = "";
        DateTime dateOfBirth = new DateTime();

        public int Age
        {
            get { return (int)(DateTime.Now.Subtract(dateOfBirth).Days/365.2425); }
            set
            {
                if ((value < 0) && (value > 120))
                {
                    throw e;
                }
                else
                {
                    _age = value;
                }
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length < 0)
                {
                    throw e;
                }
                else
                {
                    _firstName = value;
                }
            }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                if (value.Length < 0)
                {
                    throw e;
                }
                else
                {
                    _patronymic = value;
                }
            }
        }

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                if (value.Length > 0)
                {
                    throw e;
                }
                else
                {
                    _secondName = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;

            }
        }


        Exception e = new ArgumentException();

        public User(string firstName, string secondName, string patronymic, DateTime dateOfBirth)
        {
            FirstName = firstName;
            SecondName = secondName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string secondName = Console.ReadLine();

            Console.Write("Введите отчество: ");
            string patronymic = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            String strDateOfBirth = Console.ReadLine();

            DateTime dateOfBirth = DateTime.Parse(strDateOfBirth);

            User user = new User(name, secondName, patronymic, dateOfBirth);
            Console.WriteLine(user.Age);
        }
    }
}
