using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class OfficeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Time { get; }

        public OfficeEventArgs(string _name)
        {
            Name = _name;
            Time = DateTime.Now.Hour;
        }

    }
}
