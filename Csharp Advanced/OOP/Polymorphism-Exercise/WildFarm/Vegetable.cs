﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Vegetable:Food
    {
        public override int Quantity { get; set; }

        public Vegetable(int quantity) : base(quantity)
        {

        }
    }
}
