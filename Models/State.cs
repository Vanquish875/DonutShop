using System;
using System.Collections.Generic;

namespace DonutShop.Models
{
    public class State
    {
        public int StateCode { get; set; }
        public string StateName { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
