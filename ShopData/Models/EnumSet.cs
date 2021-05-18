namespace Shop.Models
{
    public class EnumSet
    {
        public enum Size
        {
            tiny = 1,
            little = 2,
            medium = 3,
            big = 4
        }

        public enum Type
        {
            electronics,
            meds,
            food,
            furniture
        }

        public enum Capacity
        {
            low = 1,
            medium = 2,
            large = 3,
            very_large = 4
        }

        public enum Speed
        {
            slow = 1,
            medium = 2,
            fast = 3,
        }

        public enum State
        {
            free,
            transit
        }

    }
}
