using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem : Catering
    {
        //Constructor
        public CateringItem(string name, double price)
        {
            Name = name;
            Price = price;
            Quantity = 25;
        }

        //Properties
        public double Price { get; set; }
        public string Name { get; private set; }
        public int Quantity { get; }

        

    }
}
