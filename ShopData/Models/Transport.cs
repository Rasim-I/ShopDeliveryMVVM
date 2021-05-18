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
            //deliveryTime - DAteTime.now
        }



        //public int CompareTo(object obj)
        //{
        //    Transport t = obj as Transport;
        //    if (t != null)
        //        return this.TimeUntilFree.CompareTo(t.TimeUntilFree);
        //    else
        //        throw new Exception("Can't compare");
        //}

        public Transport(string name)
        {
            this.name = name;
            state = State.free;
            //this.speed = speed;
            //this.capacity = capacity;

        }

    }
}
