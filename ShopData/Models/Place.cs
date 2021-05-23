namespace Shop
{
    public class Place : Base
    {
        public int distance { get; set; }

        public override string ToString()
        {
            return name;
        }

        //int delivery_time

        public Place(string name, int distance)
        {
            this.distance = distance;
            this.name = name;
        }

        public Place()
        {

        }

    }
}
