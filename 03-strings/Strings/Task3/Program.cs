using System;
using System.Globalization;

namespace Task3
{
    class Program
    {
        public static void GetLocInfo(CultureInfo cl1, CultureInfo cl2)
        {
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Name", cl1.Name, cl2.Name);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Full date time pattern", cl1.DateTimeFormat.FullDateTimePattern, cl2.DateTimeFormat.FullDateTimePattern);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "List separator", cl1.TextInfo.ListSeparator, cl2.TextInfo.ListSeparator);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Number Decimal Separator", cl1.NumberFormat.NumberDecimalSeparator, cl2.NumberFormat.NumberDecimalSeparator);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Percent Group Separator", cl1.NumberFormat.PercentGroupSeparator, cl2.NumberFormat.PercentGroupSeparator);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Number Decimal Digits", cl1.NumberFormat.NumberDecimalDigits, cl2.NumberFormat.NumberDecimalDigits);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Number Group Separator", cl1.NumberFormat.NumberGroupSeparator, cl2.NumberFormat.NumberGroupSeparator);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Currency Positive Pattern", cl1.NumberFormat.CurrencyPositivePattern, cl2.NumberFormat.CurrencyPositivePattern);
        }
        static void Main(string[] args)
        {
            String localiz1;
            String localiz2;

            Console.Write("Введите первую локализацию: ");
            localiz1 = Console.ReadLine();

            Console.Write("Введите вторую локализацию: ");
            localiz2 = Console.ReadLine();

            CultureInfo cl1 = new CultureInfo(localiz1);
            CultureInfo cl2 = new CultureInfo(localiz2);

            GetLocInfo(cl1, cl2);

        }
    }
}
