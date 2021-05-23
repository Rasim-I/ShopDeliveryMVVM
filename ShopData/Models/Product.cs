using static Shop.Models.EnumSet;
using Type = Shop.Models.EnumSet.Type;

namespace Shop
{
    public class Product : Base
    {
        public override string ToString()
        {
            return name;
        }


        public Size size { get; set; }
        public Type type { get; set; }
        public int weight { get; set; }
        public int quantity { get; set; }


        public Product(string name, Type type, int weight, Size size, int quantity)
        {
            this.quantity = quantity;
            this.name = name;
            this.type = type;
            this.weight = weight;
            this.size = size;
        }


        public Product() { }
    }
}
