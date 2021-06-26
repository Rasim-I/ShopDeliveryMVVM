using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    public class CapaciousTransportModel : TransportModel
    {
        public CapaciousTransportModel(string name) : base(name)
        {
            //this.name = name;
            capacity = EnumSet.Capacity.large;
            speed = EnumSet.Speed.slow;
        }


        public override bool isCompatible(ProductModel product)
        {
             return true;
        }

    }
}
