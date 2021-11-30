using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Prize
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Prize(int ID, string Title, string Description)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
        }

        public Prize(string Title, string Description)
        {
            this.ID = 0;
            this.Title = Title;
            this.Description = Description;
        }

        public bool IsIDEquals(Prize prize)
        {
            if (prize.ID == this.ID)
            {
                return true;
            }
            return false;
        }
    }
}
