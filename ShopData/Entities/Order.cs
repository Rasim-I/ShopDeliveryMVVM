using Shop;
using ShopData.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderTime { get; set; }

        [EnumDataType(typeof(OrderState))]
        public OrderState State { get; set; }

        [ForeignKey(nameof(transport))]
        public Guid TransportId { get; set; }
        public Transport transport { get; set; }

        [ForeignKey(nameof(place))]
        public Guid PlaceId { get; set; }
        public Place place { get; set; }

        [ForeignKey(nameof(product))]
        public Guid ProductId { get; set; }
        public Product product { get; set; }

        public string Customer { get; set; }

        public DateTime EstOrdDeliveryTime { get; set; }
    }
}
