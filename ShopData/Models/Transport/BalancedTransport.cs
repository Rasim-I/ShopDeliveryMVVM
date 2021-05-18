using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    public class BalancedTransport : Transport
    {
        public BalancedTransport(string name) : base(name)
        {
            this.name = name;
            capacity = EnumSet.Capacity.medium;
            speed = EnumSet.Speed.medium;
        }
    }
}
