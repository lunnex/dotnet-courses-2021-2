using System;

namespace Task1
{
    class User
    {
        Exception e = new ArgumentException();
        private string _firstName = "";
        private string _secondName = "";
        private string _patronymic = "";
        DateTime dateOfBirth;

        public int Age
        {
            get { return (int)(DateTime.Now.Subtract(dateOfBirth).Days / 365.2425); }

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

        public User(string firstName, string secondName, string patronymic, DateTime dateOfBirth)
        {
            FirstName = firstName;
            SecondName = secondName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
        }
    }

    class Employee : User
    {
        Exception e = new ArgumentException();
        private DateTime _dateOfRecruting;
        
        public DateTime DateOfRecruting
        {
            get { return _dateOfRecruting; }
            set
            {
                if (value < DateTime.Today && value > DateOfBirth)
                {
                    _dateOfRecruting = value;
                }
                else
                {
                    throw e;
                }
            }
        }

        public int Experience
        {
            get { return (int)((DateTime.Today.Subtract(_dateOfRecruting)).Days / 365.2425); }
        }

        public string Title { get; set; }


        public Employee(string firstName, string secondName, string patronymic, DateTime dateOfBirth, DateTime dateOfRecruting, string title) : base (firstName, secondName, patronymic, dateOfBirth)
        {
            FirstName = firstName;
            SecondName = secondName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            DateOfRecruting = dateOfRecruting;
            Title = title;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DateTime db = DateTime.Parse("09.09.1970");
            DateTime dr = DateTime.Parse("09.09.1992");
            Employee empl = new Employee("name", "sname", "patr", db, dr, "Тестировщик");

        }
    }
}
