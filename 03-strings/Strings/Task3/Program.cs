using System;
using System.Globalization;

namespace Task3
{
    class Program
    {
        public static void GetLocInfo(CultureInfo cl1, CultureInfo cl2)
        {
            PrintInfo("Name", cl1.Name, cl2.Name);
            PrintInfo("Full Date Time Pattern", cl1.DateTimeFormat.FullDateTimePattern, cl2.DateTimeFormat.FullDateTimePattern);
            PrintInfo("List Separator", cl1.TextInfo.ListSeparator, cl2.TextInfo.ListSeparator);
            PrintInfo("Number Decimal Separator", cl1.NumberFormat.NumberDecimalSeparator, cl2.NumberFormat.NumberDecimalSeparator);
            PrintInfo("Percent Group Separator", cl1.NumberFormat.PercentGroupSeparator, cl2.NumberFormat.PercentGroupSeparator);
            PrintInfo("Number Decimal Digits", cl1.NumberFormat.NumberDecimalDigits, cl2.NumberFormat.NumberDecimalDigits);
            PrintInfo("Number Group Separator", cl1.NumberFormat.NumberGroupSeparator, cl2.NumberFormat.NumberGroupSeparator);
            PrintInfo("Currency Positive Pattern", cl1.NumberFormat.CurrencyPositivePattern, cl2.NumberFormat.CurrencyPositivePattern);
        }

        private static void PrintInfo(string property, object value1, object value2)
        {
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", property, value1, value2);

        }

        static void Main(string[] args)
        {
            //String localiz1;
            //String localiz2;

            Console.Write("Введите первую локализацию: ");
            String localiz1 = Console.ReadLine();

            Console.Write("Введите вторую локализацию: ");
            String localiz2 = Console.ReadLine();

            CultureInfo cl1 = new CultureInfo(localiz1);
            CultureInfo cl2 = new CultureInfo(localiz2);

            GetLocInfo(cl1, cl2);

        }
    }
}
