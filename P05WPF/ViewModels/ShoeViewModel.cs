using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using P06Shop.Shared.Shop;

namespace P05WPF.ViewModels
{
    public class ShoeViewModel //To jest tak samo jak CityViewModel
    {
        public int Id { get; set; }
        public double ShoeSize { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        internal ShoeViewModel(Shoe shoe)
        {
            Name = shoe.Name;
            Id = shoe.Id;
            ShoeSize = shoe.ShoeSize;
            Description = shoe.Description;
        }
    }
}
