﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Shop
{
    public class Shoe
    {
        public int Id { get; set; }

        public double ShoeSize { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }
        public Shoe() { }
        public Shoe(double ShoeSize, string Description, string Name) {
            this.ShoeSize = ShoeSize;
            this.Description = Description;
            this.Name = Name;
        }
    }
}
