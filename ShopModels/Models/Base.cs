using System;

namespace Shop
{
    public class Base //remove this
    {
        public Guid _Id{ get; set; }

        public string _name;


        public Base()
        {
            _Id = Guid.NewGuid();
        }

    }
}
