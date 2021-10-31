using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Employee : User, IEquatable<Employee>
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
                    throw new ArgumentException();
                }
            }
        }

        public bool Equals(Employee employee)
        {

            return this.Age == employee.Age && this.DateOfBirth == employee.DateOfBirth && this.DateOfRecruting == employee.DateOfRecruting &&
                this.FirstName == employee.FirstName && this.SecondName == employee.SecondName && this.Patronymic == employee.Patronymic && this.Title == employee.Title;
        }

        public int Experience
        {
            get { return (int)((DateTime.Today.Subtract(_dateOfRecruting)).Days / 365.2425); }
        }

        public string Title { get; set; }


        public Employee(string firstName, string secondName, string patronymic, DateTime dateOfBirth, DateTime dateOfRecruting, string title) : base(firstName, secondName, patronymic, dateOfBirth)
        {
            FirstName = firstName;
            SecondName = secondName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            DateOfRecruting = dateOfRecruting;
            Title = title;
        }
    }
}
