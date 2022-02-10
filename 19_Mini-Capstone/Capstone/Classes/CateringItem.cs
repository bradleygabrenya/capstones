using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem : Catering
    {
        //Constructor
        public CateringItem(string name, decimal price, string productId)
        {
            Name = name;
            Price = price;
            ProductId = productId;
            Quantity = 25;
        }

        //Properties
        public decimal Price { get; set; }
        public string Name { get; private set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }

        

    }
}
