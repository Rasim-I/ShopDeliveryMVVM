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

        public FastTransport() { }

        public override bool isCompatible(Product product)
        {
            if (product.type == EnumSet.Type.furniture || product.size > EnumSet.Size.little)
                return false;
            else
                return true;
        }

    }
}
