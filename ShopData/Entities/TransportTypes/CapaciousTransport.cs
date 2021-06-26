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
    [Table("CapaciousTransports")]
    public class CapaciousTransport : Transport
    {
        public CapaciousTransport()
        {
            capacity = Capacity.large;
            speed = Speed.slow;
        }

        //public override bool isCompatible(Product product)
        //{
        //    return true;
        //}
    }
}
