using System;

namespace Task1
{
    class User
    {
        private string _firstName = "";
        private string _secondName = "";
        private string _patronymic = "";
        DateTime dateOfBirth;

        public int Age
        {
            get { return (int)(DateTime.Now.Subtract(dateOfBirth).Days/365.2425); }
            
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
                if (value.Length < 0)
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
                if (value < DateTime.Today)
                    dateOfBirth = value;
                else throw e;

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

            DateTime dateOfBirth = DateTime.Parse("03/10/2021");


            User user = new User("name", "surName", "patr", dateOfBirth);
            Console.WriteLine(user.Age);
        }
    }
}
