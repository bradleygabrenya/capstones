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
        //{
        //    get
        //    {
        //        //if (Quantity == 0)
        //        //{
        //        //    Quantity.ToString("SOLD OUT");
        //        //}
        //        //return Quantity
        //        return Quantity;

        //    }
        //    set
        //    {

        //    }
        //}
           
        public string ProductId { get; set; }


        public void SelectProducts(CateringItem[] items, string productIdInput)
        {
            foreach (CateringItem item in items)
            {
                if (base.Balance < Price)
                {
                    throw new Exception("Insufficient funds.");
                }
                else if (Quantity.ToString() == "SOLD OUT")
                {
                    throw new Exception("Item not available.");
                }
                else if (!base.inventory.Contains(productIdInput))
                {
                    throw new Exception("Product not found.");
                }
                else if (productIdInput == ProductId)
                {
                    Quantity -= 1;
                    base.Balance -= Price;
                }
            }
            
        }


    }
}
