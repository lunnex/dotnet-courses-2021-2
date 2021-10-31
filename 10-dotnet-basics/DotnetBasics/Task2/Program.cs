using System;

namespace Task2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("John", "Deacon", "", DateTime.Parse("19.08.1951"), DateTime.Parse("13.07.1973"), "bass");
            Employee employee2 = new Employee("Roger", "Tailor", "", DateTime.Parse("26.07.1949"), DateTime.Parse("13.07.1973"), "drummer");
            Employee employee3 = new Employee("Roger", "Tailor", "", DateTime.Parse("26.07.1949"), DateTime.Parse("13.07.1973"), "drummer");

            Console.WriteLine(employee1.Equals(employee2));
            Console.WriteLine(employee2.Equals(employee3));
        }
    }
}
