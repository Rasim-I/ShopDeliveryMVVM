using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    public class FastTransport : Transport
    {
        public FastTransport(string name) : base(name)
        {
            this.name = name;
            capacity = EnumSet.Capacity.low;
            speed = EnumSet.Speed.fast;
        }
    }
}
