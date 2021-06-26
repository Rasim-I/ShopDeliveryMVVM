using ShopData.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = ShopData.Entities.Enums.Type;

namespace ShopData.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string name { get; set; }

        [EnumDataType(typeof(Size))]
        public Size size { get; set; }

        [EnumDataType(typeof(Type))]
        public Type type { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }

    }
}
