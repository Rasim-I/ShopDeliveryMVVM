using Shop.Models;
using ShopData.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopData.Entities
{
    [Table("BalancedTransports")]
    public class BalancedTransport : Transport
    {
        public BalancedTransport()
        {
            capacity = Capacity.medium;
            speed = Speed.medium;
        }

        //public override bool isCompatible(Product product)
        //{
        //    if (product.type == EnumSet.Type.furniture && product.size >= EnumSet.Size.medium)
        //        return false;
        //    else
        //        return true;
        //}

    }
}
