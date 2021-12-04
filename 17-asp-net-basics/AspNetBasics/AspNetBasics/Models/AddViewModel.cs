using Entities;
using System;
using System.Collections.Generic;

namespace AspNetBasics.Models
{
    public class AddViewModel
    {
        public bool[] prizesIsChecked { get; set; }
        public List<Prize> prizes { get; set; }
        public User User { get; set; }
    }
}
