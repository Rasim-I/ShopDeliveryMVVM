﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Entities
{
    public class Place
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public int distance { get; set; }

    }
}
