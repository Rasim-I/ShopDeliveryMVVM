using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    public class FastTransportModel : TransportModel
    {
        public FastTransportModel(string name) :base(name)
        {
            this.name = name;
            capacity = EnumSet.Capacity.low;
            speed = EnumSet.Speed.fast;
        }


        public override bool isCompatible(ProductModel product)
        {
            if (product.type == EnumSet.Type.furniture || product.size > EnumSet.Size.little)
                return false;
            else
                return true;
        }

    }
}
