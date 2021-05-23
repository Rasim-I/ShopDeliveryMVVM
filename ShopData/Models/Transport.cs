using System;
using static Shop.Models.EnumSet;

namespace Shop
{
    public class Transport : Base
    {

        public Capacity capacity { get; set; }

        public Speed speed { get; set; }

        public State state { get; set; }

        public TimeSpan TimeUntilFree { get; set; }

        public void Transit(TimeSpan time)
        {
            state = State.transit;
            TimeUntilFree += time;
        }



        public Transport(string name)
        {
            this.name = name;
            state = State.free;


        }

        public virtual bool isCompatible(Product product)
        {
                return true;
        }


        public Transport() { }
    }
}
