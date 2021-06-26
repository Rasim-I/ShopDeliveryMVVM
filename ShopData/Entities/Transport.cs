using ShopData.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopData.Entities
{
    public class Transport
    {
        public Guid Id { get; set; }
        public string name { get; set; }

        [EnumDataType(typeof(Capacity))]
        public Capacity capacity { get; set; }

        [EnumDataType(typeof(Speed))]
        public Speed speed { get; set; }

        [EnumDataType(typeof(State))]
        public State state { get; set; }
        public Int64 TimeUntilFree { get; set; }


        //public abstract bool isCompatible(Product product)
        //{
        //    return true;
        //}
    }
}
