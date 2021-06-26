using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using ShopData.Entities.Enums;
using Type = ShopData.Entities.Enums.Type;

namespace ShopData.Entities
{
    [Table("FastTransports")]
    public class FastTransport : Transport
    {
        public FastTransport()
        {
            capacity = Capacity.low;
            speed = Speed.fast;
        }


    }
}
