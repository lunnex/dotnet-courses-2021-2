using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Office
    {
        public event EventHandler<OfficeEventArgs> PersonCame;
        public event EventHandler<OfficeEventArgs> PersonLeft;

        public void Come(Person person)
        {

            PersonCame?.Invoke(this, new OfficeEventArgs(person.Name));
            PersonCame += person.SayHello;
        }

        public void Left(Person person)
        {
            PersonCame -= person.SayHello;
            PersonLeft?.Invoke(this, new OfficeEventArgs(person.Name));
        }

    }
}
