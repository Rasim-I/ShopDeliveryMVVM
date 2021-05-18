using System;

namespace Shop
{
    public class Base //remove this
    {
        public Guid Id
        {
            get; set;
        }

        public string name
        {
            get; set;
        }


        public Base()
        {
            Id = Guid.NewGuid();
        }

    }
}
