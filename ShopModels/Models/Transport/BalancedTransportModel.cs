using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    public class BalancedTransportModel : TransportModel
    {
        public BalancedTransportModel(string name) : base(name)
        {
            capacity = EnumSet.Capacity.medium;
            speed = EnumSet.Speed.medium;
        }


        public override bool isCompatible(ProductModel product)
        {
            if (product.type == EnumSet.Type.furniture && product.size >= EnumSet.Size.medium)
                return false;
            else
                return true;
        }

    }
}
