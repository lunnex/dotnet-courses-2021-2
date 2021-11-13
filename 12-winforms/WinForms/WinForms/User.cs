using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinForms
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                return (AgeCalculation(DateOfBirth));
            }
        }
        public IList<string> ListOfPrize = new List<string>();
        public string PrizeStr { get; set; }

        public static int AgeCalculation(DateTime dateTime)
        {
            int years = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now.Month == dateTime.Month &&
                DateTime.Now.Day < dateTime.Day ||
                DateTime.Now.Month < dateTime.Month)
            {
                years--;
            }
            return years;
        }

        public static string GetStringOfPrizes(IList<string> inputList)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inputList.Count; i++)
            {
                sb.Append(inputList[i]);

                if(inputList.Count - i > 1)
                {
                    sb.Append(", ");
                }

            }
            return sb.ToString();
        }

        public void RemovePrizeIfItHasBeenDeleted(string[] prizes)
        {
            for (int i = 0; i < this.ListOfPrize.Count; i++)
            {
                if (!prizes.Contains(this.ListOfPrize[i]))
                {
                    this.ListOfPrize.Remove(this.ListOfPrize[i]);
                }
            }
            this.PrizeStr = GetStringOfPrizes(this.ListOfPrize);
        }

        public void EditPrize(string oldPrize, string newPrize)
        {
            for (int i = 0; i < ListOfPrize.Count; i++)
            {
                if (oldPrize == ListOfPrize[i])
                {
                    ListOfPrize[i] = newPrize;
                }
            }
            this.PrizeStr = GetStringOfPrizes(this.ListOfPrize);
        }

        public bool IsIDEquals(User user)
        {
            if (user.ID == this.ID)
            {
                return true;
            }
            return false;
        }

        public User(int ID, string FirstNme, string LastName, string DateOfBirth, string PrizeStr) 
        {
            this.ID = ID;
            this.FirstName = FirstNme;
            this.LastName = LastName;
            this.DateOfBirth = DateTime.Parse(DateOfBirth);
            this.PrizeStr = PrizeStr;
            string [] alluxaryStrArr = PrizeStr.Split(",");
            foreach (string str in alluxaryStrArr)
            {
                this.ListOfPrize.Add(str);
            }
            
        }

        public User(int ID, string FirstNme, string LastName, string DateOfBirth, IList<string> ListOfPrize)
        {
            this.ID = ID;
            this.FirstName = FirstNme;
            this.LastName = LastName;
            this.DateOfBirth = DateTime.Parse(DateOfBirth);
            foreach (string str in ListOfPrize)
            {
                this.ListOfPrize.Add(str);
            }
            this.PrizeStr = GetStringOfPrizes(ListOfPrize);

        }
    }
}
