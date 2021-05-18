using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    class CapaciousTransport : Transport
    {
        public CapaciousTransport(string name) : base(name)
        {
            this.name = name;
            capacity = EnumSet.Capacity.large;
            speed = EnumSet.Speed.slow;
        }
    }
}
