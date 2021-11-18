using System;
using System.Collections.Generic;
using System.Text;

namespace WinForms
{
    public class Data
    {
        public IList<Prize> prizes = new List<Prize>()
        {
            new Prize (0, "Нобелевская премия по физике", ""),
            new Prize (1, "Оскар", ""),
            new Prize (2, "Золотая малина", "")
        };


        public IList<User> users = new List<User>()
        {
            new User (0, "Нильс", "Бор", "07.10.1885", new List<string> {"Нобелевская премия по физике"}),
            new User (1, "Бен", "Афффлек", "15.08.1972", new List<string> {"Золотая малина"}),
            new User (2, "Джек", "Николсон", "22.04.1937", new List<string> {"Оскар"}),
        };
    }
}
